using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Domain.Entities.HRM
{
    public class Employee  : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }   = string.Empty;
        public decimal Salary { get; set; }
    }
}
