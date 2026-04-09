using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.CQRS.Command;
using Template.Application.CQRS.Query;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceRequestCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetServiceRequestByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
