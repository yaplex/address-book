using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Models;
using ITSMCodingTest.Repository;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Commands
{
    public class CreateAddressBookRecordCommandHandler: IRequestHandler<CreateAddressBookRecordCommand>
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
            await _repository.SaveAsync(_mapper.Map<AddressRecord>(request.Record));
            return Unit.Value;
        }
    }
}