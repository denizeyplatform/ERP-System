using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Attendance.Command.Handler
{
    public class CheckInAttendanceHandler : IRequestHandler<CheckInAttendanceCommand, bool>
    {
        public Task<bool> Handle(CheckInAttendanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
