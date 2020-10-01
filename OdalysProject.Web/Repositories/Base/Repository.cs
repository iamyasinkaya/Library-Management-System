using Microsoft.EntityFrameworkCore;
using OdalysProject.Web.Data;
using OdalysProject.Web.Interfaces.Base;
using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(int Id)
        {
            var result = await _applicationDbContext.Set<T>().FindAsync(Id);

            _applicationDbContext.Remove(result);
            await _applicationDbContext.SaveChangesAsync();

            return result;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _applicationDbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _applicationDbContext.Entry(entity).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
