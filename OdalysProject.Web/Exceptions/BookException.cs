using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Exceptions
{
    public class BookException : Exception
    {

        public  BookException(Book book)
        {

            if (book == null)
            {
                var message = "Varlık boş olamaz...";
                
            }
        }
        
    }
}
