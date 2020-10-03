using FluentValidation;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Bu alan boş geçilemez!");
        }
    }
}
