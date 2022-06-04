using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Repository;
using MediatR;

namespace ITSMCodingTest.Domain.AddressBook.Queries
{
    public class GetAllRecordsQueryHandler: IRequestHandler<GetAllRecordsQuery, IEnumerable<AddressBookRecordDto>>
    {
        private readonly IAddressBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllRecordsQueryHandler(IAddressBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AddressBookRecordDto>> Handle(GetAllRecordsQuery request, CancellationToken cancellationToken)
        {
            var dbRecords = await _repository.LoadAllAsync();
            return _mapper.Map<IEnumerable<AddressBookRecordDto>>(dbRecords);
        }
    }
}