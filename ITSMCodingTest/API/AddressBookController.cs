using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Domain.AddressBook.Commands;
using ITSMCodingTest.Domain.AddressBook.Queries;
using MediatR;

namespace ITSMCodingTest.API
{
    public class AddressBookController : ApiController
    {
        private readonly IMediator _mediator;
        private static readonly List<AddressBookRecordDto> _inMemoryCache = new List<AddressBookRecordDto>();
        private static int _index = 15;

        public AddressBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<controller>
        public async Task<IEnumerable<AddressBookRecordDto>> Get()
        {
            var allRecords = await _mediator.Send(new GetAllRecordsQuery());
            return allRecords;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task Post([FromBody] AddressBookRecordDto record)
        {
            await _mediator.Send(new CreateAddressBookRecordCommand(record));

            record.Id = _index++;
            _inMemoryCache.Add(record);

            Thread.Sleep(1000); // long running operation
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] AddressBookRecordDto record)
        {
            _inMemoryCache.Remove(_inMemoryCache.Find(x => x.Id == id));
            _inMemoryCache.Add(record);

            Thread.Sleep(1000); // long running operation
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _inMemoryCache.Remove(_inMemoryCache.Find(x => x.Id == id));

            Thread.Sleep(1000); // long running operation
        }
    }
}