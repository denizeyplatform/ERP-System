using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Common;
using Template.Application.CQRS.Query;
using Template.Application.DTO;
using Template.Application.Features;
using Template.Domain.Interfaces;

namespace Template.Application.CQRS.Handler
{
    public class GetServiceRequestByIdHandler
    : IRequestHandler<GetServiceRequestByIdQuery, GlobalApiResponse<ServiceRequestDto>>
    {
        //private readonly IRepository<ServiceRequest> _repository;
        private readonly ILogger<GetServiceRequestByIdHandler> _logger;

        public GetServiceRequestByIdHandler(
            //IRepository<ServiceRequest> repository,
            ILogger<GetServiceRequestByIdHandler> logger)
        {
            //_repository = repository;
            _logger = logger;
        }

        public async Task<GlobalApiResponse<ServiceRequestDto>> Handle(
            GetServiceRequestByIdQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching ServiceRequest {Id}", request.Id);

            //var entity = await _repository.GetByIdAsync(request.Id);

            //if (entity == null)
            //    return GlobalApiResponse<ServiceRequestDto>
            //        .FailureResponse("Not Found");

            //var dto = new ServiceRequestDto(entity.Id, entity.Title);

            //return GlobalApiResponse<ServiceRequestDto>
            //    .SuccessResponse(dto);
            return new GlobalApiResponse<ServiceRequestDto>();
        }
    }
}
