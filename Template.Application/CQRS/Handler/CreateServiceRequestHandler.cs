using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Common;
using Template.Application.CQRS.Command;
using Template.Application.Features;
using Template.Domain.Interfaces;

namespace Template.Application.CQRS.Handler
{
    // Application/Features/ServiceRequests/Commands/CreateServiceRequestHandler.cs

    public class CreateServiceRequestHandler
    : IRequestHandler<CreateServiceRequestCommand, GlobalApiResponse<Guid>>
    {
        //private readonly IRepository<ServiceRequest> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateServiceRequestHandler> _logger;

        public CreateServiceRequestHandler(
           // IRepository<ServiceRequest> repository,
            IUnitOfWork unitOfWork,
            ILogger<CreateServiceRequestHandler> logger)
        {
            //_repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<GlobalApiResponse<Guid>> Handle(
            CreateServiceRequestCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Creating ServiceRequest with title {Title}",
                request.Title);

            //var entity = new ServiceRequest(request.Title);

           // await _repository.AddAsync(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //_logger.LogInformation(
            //    "ServiceRequest created successfully with ID {Id}",
            //    entity.Id);

            //return GlobalApiResponse<Guid>
            //    .SuccessResponse(entity.Id, "Created successfully");
            return new GlobalApiResponse<Guid>();
        }
    }
}
