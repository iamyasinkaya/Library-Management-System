using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class Student : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Öğrenci Kimliği")]
        public int StudentId { get; set; }

        [Display(Name ="Adı")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }


        [Display(Name = "Soyadı")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Öğrenci Numarası")]
        [DataType(DataType.Text)]
        public string StudentNumber { get; set; }

        
        [Display(Name ="E-posta")]
        [DataType(DataType.Text)]
        public string EmailAddress { get; set; }


        [Display(Name ="Telefon Numarası")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        

    }

    
}
