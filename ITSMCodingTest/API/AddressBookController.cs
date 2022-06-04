using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using ITSMCodingTest.Common.Dto;

namespace ITSMCodingTest.API
{
    public class AddressBookController : ApiController
    {
        private static readonly List<AddressBookRecordDto> _inMemoryCache = new List<AddressBookRecordDto>();
        private static int _index = 15;
        static AddressBookController()
        {
            var retult = new List<AddressBookRecordDto>
            {
                new AddressBookRecordDto
                {
                    Address = "111 Pacific Ave.",
                    AddressLine2 = "Apt 1234",
                    City = "Toronto",
                    Country = "Canada",
                    EmailAddress = "alex@yaplex.com",
                    FirstName = "Alex",
                    LastName = "Shapovalov",
                    Id = 13,
                    PhoneNumber = "647 328 3809",
                    PostalZip = "M6P 2P2",
                    ProvinceState = "Ontario"
                },
                new AddressBookRecordDto
                {
                    Address = "222 Pacific Ave.",
                    City = "Toronto 2",
                    Country = "Canada 2",
                    EmailAddress = "alex2@yaplex.com",
                    FirstName = "Alex 2",
                    LastName = "Shapovalov 2",
                    Id = 14,
                    PhoneNumber = "647 328 3809 2",
                    PostalZip = "M6P 2P3",
                    ProvinceState = "Ontario 2"
                }
            };
            _inMemoryCache.AddRange(retult);
        }

        // GET api/<controller>
        public IEnumerable<AddressBookRecordDto> Get()
        {
            foreach (var a in _inMemoryCache)
                a.FullAddress = $"{a.Address} {a.AddressLine2}, {a.City}, {a.ProvinceState} {a.PostalZip} {a.Country}";

            return _inMemoryCache;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] AddressBookRecordDto record)
        {
            record.Id = _index++;
            _inMemoryCache.Add(record);

            Thread.Sleep(1000); // long running operation
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] AddressBookRecordDto record)
        {
            _inMemoryCache.Remove(_inMemoryCache.Find(x => x.Id == id));
            _inMemoryCache.Add(record);

            Thread.Sleep(1000); // long running operation
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _inMemoryCache.Remove(_inMemoryCache.Find(x => x.Id == id));

            Thread.Sleep(1000); // long running operation
        }
    }
}