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
            CreateMap<AddressRecord, AddressBookRecordDto>().ForMember(d=>d.FullAddress, o=>o.MapFrom(s=> $"{s.Address} {s.AddressLine2} {s.City} {s.ProvinceState} {s.PostalZip} {s.Country}"));
        }
    }
}