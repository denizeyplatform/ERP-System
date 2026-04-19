using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;

namespace Template.Application.Common.Validations.Attendance
{
    public class AttendanceDateRangeValidation : AbstractValidator<AttendanceDateRangeDto>
    {
        public AttendanceDateRangeValidation()
        {
            RuleFor(x=> x.StartDate).NotEmpty().WithMessage("Start date is required");
            RuleFor(x=> x.EndDate).NotEmpty().WithMessage("End date is required");
        }
    }
}
