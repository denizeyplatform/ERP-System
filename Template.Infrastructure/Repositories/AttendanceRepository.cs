using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(ApplicationDBContext context) : base(context)
        {
                
        }

        public Task<bool> checkIn(Attendance attendance)
        {
            attendance.IsChecked = true;
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<bool> checkOut(Attendance attendance)
        {
            attendance.IsChecked = false;
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
