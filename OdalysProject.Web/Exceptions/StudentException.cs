using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OdalysProject.Web.Exceptions
{
    public class StudentException : Exception
    {
        
    }

    [Serializable]
    public class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {

        }

        public InvalidStudentNameException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }

    }


}
