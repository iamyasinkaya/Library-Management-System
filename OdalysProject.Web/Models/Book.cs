using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdalysProject.Web.Enums;
using OdalysProject.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Models
{
    public class Book : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Kitap Numarası")]
        public int BookId { get; set; }

        [Display(Name = "Kitap Adı")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name = "ISBN")]
        [DataType(DataType.Text)]
        public string ISBN { get; set; }

        [Display(Name = "Resim")]
        [DataType(DataType.Upload)]
        public string Image { get; set; }


        [Display(Name = "Miktar")]
        public int Quantity { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Desciption { get; set; }

        // Enum
        [Display(Name = "Kitap Durumu")]
        public BookStatus BookStatus { get; set; }

        //Model

        

        [Display(Name="Yazar")]
        
        public Author Author { get; set; }

        [Display(Name = "Kategori Numarası")]

        public int CategoryId { get; set; }

        [Display(Name="Kategori")]
        public Category Category { get; set; }

        [Display(Name = "Yayınevi Numarası")]

        public int PublisherId { get; set; }

        [Display(Name="Yayınevi")]
        public Publisher Publisher { get; set; }


    }


}
