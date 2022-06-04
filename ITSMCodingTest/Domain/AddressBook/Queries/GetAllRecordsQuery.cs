using System.Collections.Generic;
using ITSMCodingTest.Common.Dto;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Queries
{
    public class GetAllRecordsQuery: IRequest<IEnumerable<AddressBookRecordDto>>
    {
        
    }
}