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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Author> CreateAsync(Author entity)
        {
            await _applicationDbContext.Author.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Author> DeleteAsync(int Id)
        {
            var result = await _applicationDbContext.Author.FindAsync(Id);

            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();


            return result;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _applicationDbContext.Author
                .Include(x=>x.Book)
                .ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int Id)
        {
            return await _applicationDbContext.Author.FindAsync(Id);
        }

        public Task<Author> UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }
    }
}
