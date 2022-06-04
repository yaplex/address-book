using System;
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
        void Add(AddressRecord record);
        Task<IEnumerable<AddressRecord>> LoadAllAsync();
        Task<AddressRecord> LoadAsync(int id);

        Task Commit();
    }
    public class AddressBookRepository: IAddressBookRepository
    {
        private readonly AddressBookEntities _dbContext;

        public AddressBookRepository(AddressBookEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(AddressRecord record)
        {
            _dbContext.AddressRecords.Add(record);
        }

        public async Task<IEnumerable<AddressRecord>> LoadAllAsync()
        {
            return await _dbContext.AddressRecords.ToListAsync();
        }

        public async Task<AddressRecord> LoadAsync(int id)
        {
            var record = await _dbContext.AddressRecords.FindAsync(id);
            return record;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}