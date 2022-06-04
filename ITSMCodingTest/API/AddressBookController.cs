using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
     
        public AddressBookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<controller>
        public async Task<IEnumerable<AddressBookRecordDto>> Get()
        {
            var allRecords = await _mediator.Send(new GetAllRecordsQuery());

            Thread.Sleep(1000); // long running operation
            
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
        }

        // PUT api/<controller>/5
        public async Task Put(int id, [FromBody] AddressBookRecordDto record)
        {
            await _mediator.Send(new UpdateAddressBookRecordCommand(id, record));
            
            Thread.Sleep(1000); // long running operation
        }

        // DELETE api/<controller>/5
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteAddressBookRecordCommand(id));

            Thread.Sleep(1000); // long running operation
        }

        [Route("api/AddressBook/upload")]
        [HttpPost]
        public string FileUpload()
        {
            //Debugger.Launch();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                if (null != postedFile)
                {
                    var extension = Path.GetExtension(postedFile.FileName);
                    var uploadPath = "/Photos/" + Guid.NewGuid() + extension;
                    var filePath = HttpContext.Current.Server.MapPath("~" + uploadPath);
                    postedFile.SaveAs(filePath);
                    return uploadPath;
                }
            }

            return string.Empty;
        }
    }
}