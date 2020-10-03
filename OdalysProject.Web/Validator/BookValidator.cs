using FluentValidation;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1,100)
                
                .WithMessage("Bu alan boş geçilemez!");

            RuleFor(x => x.ISBN)
                .NotEmpty()
                .WithMessage("Bu alan boş geçilemez!");
                

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Bu alan boş geçilemez!");


            RuleFor(x => x.Desciption)
                .NotEmpty()
                .WithMessage("Bu alan boş geçilemez!");


            RuleFor(x => x.ISBN).NotEmpty()
                .WithMessage("Bu alan boş geçilemez!");

            

            RuleFor(x => x.Desciption)
                .MinimumLength(2)
                .MaximumLength(1000)
                .WithMessage("Bu alan boş geçilemez!");
        }
    }
}
