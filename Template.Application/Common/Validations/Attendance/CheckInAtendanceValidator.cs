using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Attendance.Command;

namespace Template.Application.Common.Validations.Attendance
{
    public class CheckInAtendanceValidator : AbstractValidator<CheckInAttendanceCommand>
    {
        public CheckInAtendanceValidator()
        {
            RuleFor(x=>x.requestDto.EmployeeId).NotEmpty().WithMessage("Employee Id is required");
            RuleFor(x => x.requestDto.CheckInTime).NotEmpty().WithMessage("Check in time is required");
            RuleFor(x => x.requestDto.CheckInTime).LessThanOrEqualTo(DateTime.Now).WithMessage("Check in time cannot be in the future");
        }
    }
}
