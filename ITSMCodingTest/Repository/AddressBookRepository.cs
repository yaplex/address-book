using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.Repository
{
    public interface IAddressBookRepository
    {
        Task SaveAsync(AddressRecord record);
    }
    public class AddressBookRepository: IAddressBookRepository
    {
        private readonly AddressBookEntities _dbContext;

        public AddressBookRepository(AddressBookEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveAsync(AddressRecord record)
        {
            _dbContext.AddressRecords.Add(record);
            await _dbContext.SaveChangesAsync();
        }
    }
}