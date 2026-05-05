using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.HRM;
using Template.Domain.Interfaces.HRM;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories.HRM
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext context) : base(context) { }
        



























        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {


            _context.Employees.Add(employee);

            var result = await _context.SaveChangesAsync();

            return result.Equals(1);
        }

    }
}
