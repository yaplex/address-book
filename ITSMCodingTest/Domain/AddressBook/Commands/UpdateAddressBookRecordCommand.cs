using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Models;
using ITSMCodingTest.Repository;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Commands
{
    public class UpdateAddressBookRecordCommand: IRequest
    {
        public int Id { get; }
        public AddressBookRecordDto Record { get; }

        public UpdateAddressBookRecordCommand(int id, AddressBookRecordDto record)
        {
            Id = id;
            Record = record;
        }
    }

    public class UpdateAddressBookRecordCommandHandler : IRequestHandler<UpdateAddressBookRecordCommand>
    {
        private readonly IAddressBookRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAddressBookRecordCommandHandler(IAddressBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateAddressBookRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.LoadAsync(request.Id);
            if (record != null)
            {
                _mapper.Map(request.Record, record);
                await _repository.Commit();
            }
            return Unit.Value;
        }
    }
}