using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.CQRS.Employee.Query
{
    public record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeDto>;
}
