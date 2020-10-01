using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class Publisher : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Yayınevi Numarası")]
        public int PublisherId { get; set; }

        [Display(Name="Yayınevi Adı")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name="Resim")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }

        [Display(Name = "Hakkında")]
        [DataType(DataType.Text)]
        public string About { get; set; }
    }
}
