using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.DTO
{
    public class CheckOutDTO
    {
        public int EmployeeId { get; set; }
        public DateTime CheckInTime { get; set; }
        public int CheckInStatus { get; set; }
    }
}
