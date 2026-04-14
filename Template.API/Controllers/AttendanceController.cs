using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.CQRS.Attendance.Command;
using Template.Application.CQRS.Attendance.Query;
using Template.Application.Features.Service.Employee;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public IMediator _mediator;

        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpPost]
        public async Task<IActionResult> CheckIn(CheckInAttendanceCommand command)
        {
            var isCkecked = await _mediator.Send(command);

            return Ok("Checked in successfully");
        }

        [HttpGet("Get/Attendance")]
        public async Task<IActionResult> GetAttendance([FromQuery] GetAttendanceQuery query)
        {
            var AttendanceList = await _mediator.Send(query);

            return Ok("Checked out successfully");
        }
    }
}
