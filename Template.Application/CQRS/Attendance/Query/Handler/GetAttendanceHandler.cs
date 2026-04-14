using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.CQRS.Attendance.Query.Handler
{
    public class GetAttendanceHandler : IRequestHandler<GetAttendanceQuery, List<AttendanceDto>>
    {
        // Inject IAttendanceService
        public Task<List<AttendanceDto>> Handle(GetAttendanceQuery request, CancellationToken cancellationToken)
        {


            // service



            return Task.FromResult(new List<AttendanceDto>());
        }
    }
}
