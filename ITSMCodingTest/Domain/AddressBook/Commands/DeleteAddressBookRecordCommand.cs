using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Repository;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Commands
{
    public class DeleteAddressBookRecordCommand: IRequest
    {
        public int Id { get; }

        public DeleteAddressBookRecordCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteAddressBookRecordCommandHandler : IRequestHandler<DeleteAddressBookRecordCommand>
    {
        private readonly IAddressBookRepository _repository;

        public DeleteAddressBookRecordCommandHandler(IAddressBookRepository repository)
        {
            _repository = repository;
            
        }
        public async Task<Unit> Handle(DeleteAddressBookRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _repository.LoadAsync(request.Id);
            if (record != null)
            {
                _repository.Delete(record);
                await _repository.Commit();
            }
            return Unit.Value;
        }
    }
}