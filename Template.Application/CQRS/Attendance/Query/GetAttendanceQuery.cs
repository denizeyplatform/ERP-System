using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.CQRS.Attendance.Query
{
    public record GetAttendanceQuery(AttendanceDateRangeDto DateRangeDto) : IRequest<List<AttendanceDto>>
    {
    }
}
