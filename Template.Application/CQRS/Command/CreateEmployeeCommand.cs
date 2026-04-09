using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Command
{
    public record CreateEmployeeCommand(string Name, string Email, decimal Salary) : IRequest<Guid>;
}
