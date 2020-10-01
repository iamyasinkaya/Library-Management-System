using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdalysProject.Web.Data;
using OdalysProject.Web.Exceptions;
using OdalysProject.Web.Interfaces;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }



        public async Task<Book> CreateAsync(Book entity)
        {
            try
            {
                _applicationDbContext.Book
                  .Include(x => x.BookStatus);


                await _applicationDbContext.Book.AddAsync(entity);

                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new BookException(entity);
            }


            return entity;
        }



        public async Task<Book> DeleteAsync(int Id)
        {
            _applicationDbContext.Book
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Include(x => x.Publisher);

            var result = await _applicationDbContext.Book.FindAsync(Id);

            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();


            return result;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _applicationDbContext.Book
                  .Include(x => x.Category)
                  .Include(x => x.Author)
                  .Include(x => x.Publisher).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int Id)
        {
            return await _applicationDbContext.Book
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Include(x => x.Publisher).FirstOrDefaultAsync(x => x.BookId == Id);
        }

        public Task<Book> UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
