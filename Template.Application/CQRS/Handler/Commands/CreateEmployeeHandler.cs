using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Command;
using Template.Domain.Entities;

namespace Template.Application.CQRS.Handler.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        

        public CreateEmployeeHandler()
        {
            
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            

            return new Guid();
        }
    }
}
