using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.CQRS.Attendance.Command;
using Template.Application.CQRS.Attendance.Query;
using Template.Application.DTO;
using Template.Application.Features.Service.Employee;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        public IMediator _mediator;
        public ILogger<AttendanceController> _logger;
        public AttendanceController(IMediator mediator, ILogger<AttendanceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> CheckIn(CheckInAttendanceCommand command)
        {
            try
            {

                _logger.LogInformation("CheckIn request is called from ${0} and at time ${1}"
                    , command.requestDto.EmployeeId, command.requestDto.CheckInTime);

                var isCkecked = await _mediator.Send(command);

                return Ok("Checked in successfully");

            } catch (Exception ex)
            {
                _logger.LogDebug($"There is an error with {ex.Message}");
                return BadRequest(ex.Message);
            }

         
        }

        [HttpGet("Get/Attendance")]
        public async Task<IActionResult> GetAttendance([FromQuery] GetAttendanceQuery query)
        {
            var AttendanceList = await _mediator.Send(query);

            return Ok("Checked out successfully");
        }
    }
}
