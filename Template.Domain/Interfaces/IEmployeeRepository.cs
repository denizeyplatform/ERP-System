using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> CreateEmployeeAsync(Employee employee);
    }
}
