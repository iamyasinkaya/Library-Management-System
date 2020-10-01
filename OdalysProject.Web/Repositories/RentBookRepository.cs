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
    public class RentBookRepository : IRentBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RentBookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(Index));
        }

        public async Task<RentBook> CreateAsync(RentBook entity)
        {
           

           await _applicationDbContext.RentBook.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public Task<RentBook> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<RentBook>> GetAllAsync()
        {
            return await _applicationDbContext.RentBook
                .Include(x => x.Book)
                .Include(x => x.Student)
                .ToListAsync();

        }

        public Task<RentBook> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<RentBook> UpdateAsync(RentBook entity)
        {
            throw new NotImplementedException();
        }
    }
}
