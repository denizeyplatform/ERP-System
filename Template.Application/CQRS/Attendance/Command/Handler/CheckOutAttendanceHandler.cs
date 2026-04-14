using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.CQRS.Attendance.Command.Handler
{
    public class CheckOutAttendanceHandler : IRequestHandler<CheckOutAttendanceCommand, bool>
    {
        // Inject IAttendanceService ....
        public Task<bool> Handle(CheckOutAttendanceCommand request, CancellationToken cancellationToken)
        {
          var dto =  request.requestDTO;
            

            // service.CheckOut(dto);





            return Task.FromResult(true);
        }
    }
}
