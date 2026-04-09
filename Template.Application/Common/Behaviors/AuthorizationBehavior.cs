using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Common.Interfaces;
using Template.Application.CQRS.Employee.Command;

namespace Template.Application.Common.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ICurrentUserService _currentUser;

        public AuthorizationBehavior(ICurrentUserService currentUser)
        {
            _currentUser = currentUser;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken ct)
        {
            // Example rule: only Admin can delete
            if (request is DeleteEmployeeCommand)
            {
                if (!_currentUser.IsInRole("Admin"))
                    throw new UnauthorizedAccessException("Not allowed");
            }

            return await next();
        }
    }
}
