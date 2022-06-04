using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.API
{
    public class AddressBookController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<AddressRecord> Get()
        {
            return new List<AddressRecord>()
            {
                new AddressRecord()
                {
                    Address = "111 Pacific Ave.",
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
                new AddressRecord()
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
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}