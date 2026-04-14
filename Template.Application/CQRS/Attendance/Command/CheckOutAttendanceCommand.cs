using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.CQRS.Attendance.Command
{
    public record CheckOutAttendanceCommand(CheckOutDTO requestDTO) : IRequest<bool>
    {
       
    }
}
