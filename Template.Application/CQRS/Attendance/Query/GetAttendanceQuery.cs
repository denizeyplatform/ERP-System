using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;
using Template.Application.Features.Interface;

namespace Template.Application.CQRS.Attendance.Query
{
    public record GetAttendanceQuery(AttendanceDateRangeDto DateRangeDto) : IRequest<List<AttendanceDto>> , ICacheable
    {
        public string CacheKey => $"attendance:{DateRangeDto.StartDate}:{DateRangeDto.EndDate}";
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(5);
    }

    public record GetProductsQuery(string? Category) : IRequest<List<string>>, ICacheable
    {
        public string CacheKey => $"products:{Category ?? "all"}";
        public TimeSpan CacheDuration => TimeSpan.FromMinutes(5);
    }

}
