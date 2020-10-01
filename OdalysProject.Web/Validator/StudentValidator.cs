using FluentValidation;
using OdalysProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdalysProject.Web.Validator
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Bu alan boş geçilemez!");
            RuleFor(x => x.StudentNumber).NotEmpty()
                .Length(6, 10)
                .Custom((studentNumber, context) =>
                {
                    var arr = new[]
                    {
                        "A","B","C","D"
                    };
                    if (!arr.Contains(studentNumber.Substring(0, 1)))
                    {
                        context.AddFailure("Öğrenci Numarası 'A', 'B', 'C','D' harfi ile başlamalıdır.");
                    }
                });
        }
    }
}
