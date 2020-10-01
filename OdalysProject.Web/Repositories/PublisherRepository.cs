using Microsoft.EntityFrameworkCore;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PublisherRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
        public async Task<Publisher> CreateAsync(Publisher entity)
        {
            await _applicationDbContext.Publisher.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();


            return entity;
        }

        public async Task<Publisher> DeleteAsync(int Id)
        {
            var result = await _applicationDbContext.Publisher.FindAsync(Id);

            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();


            return result;
        }

        public  async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _applicationDbContext.Publisher.ToListAsync();
        }

        public async Task<Publisher> GetByIdAsync(int Id)
        {
            return await _applicationDbContext.Publisher.FindAsync(Id);
        }

        public Task<Publisher> UpdateAsync(Publisher entity)
        {
            throw new NotImplementedException();
        }
    }
}
