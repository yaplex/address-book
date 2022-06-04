using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using AutoMapper;
using ITSMCodingTest.Domain.AddressBook.Queries;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.API
{
    public class CountriesProviderController: ApiController
    {
        private readonly IMapper _mapper;
        const string CacheKey = "ListOfSupportedCountriesCacheKey";

        public CountriesProviderController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<CountryView>> Get()
        {
            try
            {
                var cache = HttpContext.Current.Cache;
                var cachedCountries = cache.Get(CacheKey);
                if (cachedCountries != null && cachedCountries is IEnumerable<CountryView> )
                {
                    return cachedCountries as IEnumerable<CountryView>;
                }

                var http = new HttpClient();
                http.BaseAddress = new Uri("https://restcountries.com");

                var result = await http.GetAsync("/v3.1/region/Americas");
                if (result.IsSuccessStatusCode)
                {
                    var allCountries = await result.Content.ReadAsAsync<IEnumerable<RestCountry>>();
                    if (null != allCountries)
                    {
                        var mappingCountriesResult = _mapper.Map<IEnumerable<CountryView>>(allCountries);
                        cache.Add(CacheKey, mappingCountriesResult, null,
                            DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
                        return mappingCountriesResult;
                    }
                }
            }
            catch
            {
                // log the issue
            }


            // fallback if services is down.
            return new List<CountryView>()
            {
                new CountryView(){Name = "Canada", ThreeLetterCode = "CAD", Flag = "https://flagcdn.com/w320/ca.png"},
                new CountryView(){Name = "United States", ThreeLetterCode = "USA", Flag = "https://flagcdn.com/w320/um.png"},
                new CountryView(){Name = "Mexico", ThreeLetterCode = "MEX", Flag = "https://flagcdn.com/w320/mx.png"}
            };

        }
    }
}