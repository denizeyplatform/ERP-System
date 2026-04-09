using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Template.Application.Common;
using Template.Application.DTO;

namespace Template.Application.CQRS.Query
{


    public record GetServiceRequestByIdQuery(Guid Id)
        : IRequest<GlobalApiResponse<ServiceRequestDto>>;
}
