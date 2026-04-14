using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<bool> checkIn(Attendance attendance);
        Task<bool> checkOut(Attendance attendance);

    }
}
