using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class RentBook : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Kiralık Kitap ID")]
        public int RentBookId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Kiralama Tarihi")]

        public DateTime RentDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Teslim Tarihi")]

        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Kitap Numarası")]

        public int BookId { get; set; }

        [Display(Name = "Kitap")]

        public Book Book { get; set; }

        [Display(Name = "Öğrenci Numarası")]


        public int StudentId { get; set; }

        [Display(Name = "Öğrenci")]

        public Student Student { get; set; }
    }
}
