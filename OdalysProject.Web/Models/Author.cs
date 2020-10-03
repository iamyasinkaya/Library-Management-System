using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class Author : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Yazar Numarası")]
        public int AuthorId { get; set; }

        [Display(Name = "Yazar Adı")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        [Display(Name = "Yazar Soyadı")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Display(Name = "Yazar Ünvanı")]
        [DataType(DataType.Text)]
        public string Nickname { get; set; }

        [Display(Name = "Yazar Hakkında")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Ölüm Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateOfDeath { get; set; }

        [Display(Name ="Kitap Numarası")]
        public int BookForeignKey { get; set; }

        [Display(Name = "Yazar Tam Adı")]
        public string FullName { get; set; }

        [Display(Name = "Kitap")]
        public Book Book { get; set; }


        public Author()
        {
            FullName = Firstname + " " + Lastname;
        }
    }
}
