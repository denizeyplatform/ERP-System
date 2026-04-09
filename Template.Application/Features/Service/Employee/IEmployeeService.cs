using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.Features.Service.Employee
{
    public interface IEmployeeService
    {
        Task<bool> createEmployee(EmployeeDto employeedto);
    }
}
