using OdalysProject.Web.Interfaces.Base;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {

        List<RentBook> GetRentBook(int Id);
    }
}
