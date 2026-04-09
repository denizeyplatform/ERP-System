using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Employee.Command
{
    public record DeleteEmployeeCommand(Guid Id) : IRequest<bool>;
}
