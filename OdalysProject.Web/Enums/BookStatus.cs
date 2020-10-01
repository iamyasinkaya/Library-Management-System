using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Enums
{
    public enum BookStatus
    {
        [Display(Name = "Aktif")]

        Active,

        [Display(Name = "Pasif")]

        Passive
    }
}
