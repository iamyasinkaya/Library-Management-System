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
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<Student> CreateAsync(Student entity)
        {
            await _applicationDbContext.Student.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();

            return entity;
        }

        public Task<Student> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _applicationDbContext.Student
                
                .ToListAsync();
        }

        public Task<Student> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public List<RentBook> GetRentBook(int Id)
        {
            var result = _applicationDbContext.RentBook
                .Include(x => x.Book)
                .Where(x => x.Student.StudentId == Id)
                .ToList();

            return result;
        }

        public Task<Student> UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
