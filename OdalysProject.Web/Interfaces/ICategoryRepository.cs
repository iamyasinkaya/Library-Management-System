using OdalysProject.Web.Interfaces.Base;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Book> GetBooks(int Id);
    }
}
