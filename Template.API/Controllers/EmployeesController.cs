using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Common;
using Template.Application.Common.Paginations;
using Template.Application.CQRS.Employee.Command;
using Template.Application.CQRS.Employee.Query;
using Template.Application.DTO;
using Template.Application.Features.Service.Employee;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IMediator mediator, IEmployeeService employeeService)
        {
            _mediator = mediator;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            var result = await _employeeService.createEmployee(new EmployeeDto());
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        //[HttpGet("blocked-attempts")]
        //public IActionResult Get(int page = 1, int pageSize = 10)
        //{
        //    var all = _store.Logs.OrderByDescending(x => x.Timestamp);

        //    var items = all
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    var paged = PagedResponse<EmployeeDto>.Create(items, all.Count(), page, pageSize);

        //    return Ok(GlobalApiResponse<PagedResponse<EmployeeDto>>.Ok(paged));
        //}

        //[HttpGet("blocked")]
        //public IActionResult Get(int page = 1, int pageSize = 10, string search = "")
        //{
        //    var query = _service.Get(page, pageSize, search);

        //    var total = _service.Get(1, int.MaxValue, search).Count; // simple count (in-memory)

        //    var paged = PagedResponse<EmployeeDto>.Create(query, total, page, pageSize);

        //    return Ok(GlobalApiResponse<PagedResponse<EmployeeDto>>.SuccessResponse(paged));
        //}

        //[HttpGet("blocked-attempts")]
        //public IActionResult GetLogs([FromQuery] PaginationParams pagination)
        //{
        //    var result = _store.Logs
        //        .OrderByDescending(x => x.Timestamp)
        //        .Where(x => string.IsNullOrEmpty(pagination.Search)
        //            || x.CountryCode.Contains(pagination.Search))
        //        .Skip((pagination.Page - 1) * pagination.PageSize)
        //        .Take(pagination.PageSize)
        //        .ToList();

        //    return Ok(GlobalApiResponse<PagedResponse<EmployeeDto>>.SuccessResponse(result));
        //}
    }
}
