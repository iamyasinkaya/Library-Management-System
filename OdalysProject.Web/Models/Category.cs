using FluentValidation;
using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class Category : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name="Kategori Numarası")]
        public int CategoryId { get; set; }

        [Display(Name ="Kategori Adı")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }

   
}
