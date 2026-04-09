using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Employee.Command
{
    public record UpdateEmployeeCommand(Guid Id, string Name, string Email, decimal Salary)
    : IRequest<bool>;
}
