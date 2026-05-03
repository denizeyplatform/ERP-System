using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.HRM;
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

        //public async Task<List<AttendenceHoursDto>> GetEmployeeHoursAsync(Guid employeeId, string month)
        //{
        //    var result = await _context.Attendances
        //        .Where(a => a.EmployeeId == employeeId
        //                 && a.Date.Month.ToString() == month).ToListAsync();

        //    var currentDayCheckIn = result.Where(x => x.Date.Day.ToString() == DateTime.Now.Day.ToString() && x.IsCheckedIn == true)
        //        .Select(x => new
        //        {
        //            dayName = x.Date.ToString("dddd"),
        //            monthName = x.Date.ToString("MMMM"),
        //            Checked = "CheckIn",
        //            Time = x.Date.ToString("hh:mm tt"),
        //            EmployeeId = x.EmployeeId
        //        }
        //    );

        //    var currentDayCheckOut = result.Where(x => x.Date.Day.ToString() == DateTime.Now.Day.ToString() && x.IsCheckedIn == false)
        //        .Select(x => new
        //        {
        //            dayName = x.Date.ToString("dddd"),
        //            monthName = x.Date.ToString("MMMM"),
        //            Checked = "CheckOut",
        //            Time = x.Date.ToString("hh:mm tt"),
        //            EmployeeId = x.EmployeeId
        //        }
        //    );
        //    var combined = currentDayCheckIn
        //                .Concat(currentDayCheckOut);


        //    var groupedResult = combined
        //        .GroupBy(x => new { x.EmployeeId, x.dayName, x.monthName })
        //        .Select(g =>
        //        {
        //            var firstCheckIn = g
        //                .Where(x => x.Checked == "CheckIn")
        //                .OrderBy(x => x.Time)
        //                .FirstOrDefault();

        //            var lastCheckOut = g
        //                .Where(x => x.Checked == "CheckOut")
        //                .OrderByDescending(x => x.Time)
        //                .FirstOrDefault();

        //            var workedHours =
        //                firstCheckIn != null && lastCheckOut != null
        //                    ? (DateTime.Parse(lastCheckOut.Time) - DateTime.Parse(firstCheckIn.Time)).TotalHours
        //                    : 0;

        //            return new AttendenceHoursDto()
        //            {
        //                EmployeeId = g.Key.EmployeeId,
        //                dayName = g.Key.dayName,
        //                monthName = g.Key.monthName,

        //                CheckIn = firstCheckIn?.Time,//.ToString("hh:mm tt"),
        //                CheckOut = lastCheckOut?.Time,//.ToString("hh:mm tt"),

        //                WorkedHours = workedHours
        //            };
        //        })
        //        .ToList();

        //    return groupedResult;

        //}

        //public async Task<List<AttendanceResultDto>> GetEmployeeAttendanceByMonthAsync(Guid employeeId, string month)
        //{
        //    var result = await _context.Attendances
        //        .Where(a => a.EmployeeId == employeeId
        //                 && a.Date.Month.ToString() == month).ToListAsync();

        //    var currentDayCheckIn = result.Where(x => x.Date.Day.ToString() == DateTime.Now.Day.ToString() && x.IsCheckedIn == true)
        //        .Select(x => new
        //        {
        //            dayName = x.Date.ToString("dddd"),
        //            monthName = x.Date.ToString("MMMM"),
        //            Checked = "CheckIn",
        //            Time = x.Date.ToString("hh:mm tt"),
        //            EmployeeId = x.EmployeeId
        //        }
        //    );

        //    var currentDayCheckOut = result.Where(x => x.Date.Day.ToString() == DateTime.Now.Day.ToString() && x.IsCheckedIn == false)
        //        .Select(x => new
        //        {
        //            dayName = x.Date.ToString("dddd"),
        //            monthName = x.Date.ToString("MMMM"),
        //            Checked = "CheckOut",
        //            Time = x.Date.ToString("hh:mm tt"),
        //            EmployeeId = x.EmployeeId
        //        }
        //    );
        //    var combined = currentDayCheckIn
        //                .Concat(currentDayCheckOut);

        //    var groupedResult = combined
        //        .GroupBy(x => new { x.EmployeeId, x.dayName, x.monthName })
        //        .Select(g => new AttendanceResultDto()
        //        {
        //            EmployeeId = g.Key.EmployeeId,
        //            Day = g.Key.dayName,
        //            Month = g.Key.monthName,

        //            CheckIns = g.Where(x => x.Checked == "CheckIn")
        //                        .Select(x => x.Time)
        //                        .ToList(),

        //            CheckOuts = g.Where(x => x.Checked == "CheckOut")
        //                         .Select(x => x.Time)
        //                         .ToList()
        //        })
        //        .ToList();

        //    return groupedResult;

        //}
    }
}
