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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
        public async Task<Category> CreateAsync(Category entity)
        {
            
            await _applicationDbContext.Category.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();


            return entity;
        }

        public async Task<Category> DeleteAsync(int Id)
        {
            var result = await _applicationDbContext.Category.FindAsync(Id);

            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();


            return result;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _applicationDbContext.Category.ToListAsync();
        }

        public List<Book> GetBooks(int Id)
        {
            var result = _applicationDbContext.Book
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .Where(x => x.Category.CategoryId == Id)
                .ToList();

            return result;
        }

        public async Task<Category> GetByIdAsync(int Id)
        {
            return await _applicationDbContext.Category.FindAsync(Id);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {

            _applicationDbContext.Entry(entity).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
