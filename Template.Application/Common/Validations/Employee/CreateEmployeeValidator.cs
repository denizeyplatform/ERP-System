using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Employee.Command;

namespace Template.Application.Common.Validations.Employee
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Salary).GreaterThan(0);
        }
    }
}
