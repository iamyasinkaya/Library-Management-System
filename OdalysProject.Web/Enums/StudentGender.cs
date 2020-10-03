using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Enums
{
    public enum StudentGender
    {
        [Display(Name ="Bay")]
        Male,
        [Display(Name ="Bayan")]
        Female,

        [Display(Name ="Diğer")]
        Other,
    }
}
