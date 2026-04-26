using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Attendance.Command.Handler
{
    public class CheckInAttendanceHandler : IRequestHandler<CheckInAttendanceCommand, bool>
    {
        public ILogger<CheckInAttendanceHandler> _logger;
        public CheckInAttendanceHandler(ILogger<CheckInAttendanceHandler> logger) { _logger = logger; }
        public Task<bool> Handle(CheckInAttendanceCommand request, CancellationToken cancellationToken)
        {
            if (request.requestDto.EmployeeId > 0)
            {
                _logger.LogInformation($"Employee with ID {request.requestDto.EmployeeId} checked in at {DateTime.UtcNow}");
                return Task.FromResult(true);
            }
            else
            {
                _logger.LogError("Invalid Employee ID for check-in.");
                return Task.FromResult(false);
            }
            
        }
    }
}
