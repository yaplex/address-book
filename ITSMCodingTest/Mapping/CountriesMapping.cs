using AutoMapper;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.Mapping
{
    public class CountriesMapping: Profile
    {
        public CountriesMapping()
        {
            CreateMap<RestCountry, CountryView>()
                .ForMember(d=>d.ThreeLetterCode, o=>o.MapFrom(s=>s.cca3))
                .ForMember(d=>d.Name, o=>o.MapFrom(s=>s.Name.Common))
                .ForMember(d=>d.Flag, o=>o.MapFrom(s=>s.Flags.Png));
        }
    }
}