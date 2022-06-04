using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.Mapping
{
    public class AddressBookMapping: Profile
    {
        public AddressBookMapping()
        {
            CreateMap<AddressBookRecordDto, AddressRecord>();
        }
    }
}