using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Query;
using Template.Application.DTO;

namespace Template.Application.CQRS.Handler.Queries
{
    public class GetAllEmployeesHandler
    : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>
    {
        

        public GetAllEmployeesHandler()
        {
            
        }

        public async Task<List<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken ct)
        {
            return await Task.FromResult(new List<EmployeeDto>());
        }
    }
}
