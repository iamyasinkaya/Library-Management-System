using FluentValidation;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Validator
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.Nickname).NotEmpty().WithMessage("Bu alan boş geçilemez!");

        }
    }
}
