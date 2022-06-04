using ITSMCodingTest.Common.Dto;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Commands
{
    public class CreateAddressBookRecordCommand: IRequest
    {
        public AddressBookRecordDto Record { get; }

        public CreateAddressBookRecordCommand(AddressBookRecordDto record)
        {
            Record = record;
        }
    }
}