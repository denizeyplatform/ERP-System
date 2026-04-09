using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Template.Application.Common;

namespace Template.Application.CQRS.Command
{


    public record CreateServiceRequestCommand(string Title)
        : IRequest<GlobalApiResponse<Guid>>;
}
