using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.Common.Validations.Employee
{
    public class CreateDepartmentValidator : AbstractValidator<EmployeeDto>
    {
        public CreateDepartmentValidator()
        {

            RuleFor(x => x.Email).EmailAddress()
                .MaximumLength(50)
                .WithMessage("Invalid email format.");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("Email must be at least 10 characters long.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
               
        }
    }
}
