using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Models;
using ITSMCodingTest.Repository;
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

    public class CreateAddressBookRecordCommandHandler : IRequestHandler<CreateAddressBookRecordCommand>
    {
        private readonly IAddressBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateAddressBookRecordCommandHandler(IAddressBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateAddressBookRecordCommand request, CancellationToken cancellationToken)
        {
            _repository.Add(_mapper.Map<AddressRecord>(request.Record));
            await _repository.Commit();
            return Unit.Value;
        }
    }
}