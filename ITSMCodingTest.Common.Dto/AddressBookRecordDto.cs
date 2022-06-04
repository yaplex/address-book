using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSMCodingTest.Common.Dto
{
    public class AddressBookRecordDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ProvinceState { get; set; }
        public string PostalZip { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FullAddress { get; set; }
    }
}
