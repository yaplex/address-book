using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ITSMCodingTest.Common.Dto;
using ITSMCodingTest.Models;

namespace ITSMCodingTest.Repository
{
    public interface IAddressBookRepository
    {
        Task SaveAsync(AddressRecord record);
        Task<IEnumerable<AddressRecord>> LoadAllAsync();
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

        public async Task<IEnumerable<AddressRecord>> LoadAllAsync()
        {
            return await _dbContext.AddressRecords.ToListAsync();
        }
    }
}