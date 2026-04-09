using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Employee.Query;
using Template.Application.DTO;

namespace Template.Application.CQRS.Employee.Handler.Queries
{
    public class GetEmployeeByIdHandler
    : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        

        public GetEmployeeByIdHandler()
        {
            
        }

        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken ct)
        {
            return await Task.FromResult(new EmployeeDto());
        }
    }
}
