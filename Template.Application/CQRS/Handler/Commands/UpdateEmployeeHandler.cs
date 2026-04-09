using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Command;

namespace Template.Application.CQRS.Handler.Commands
{
    public class UpdateEmployeeHandler
    : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        

        public UpdateEmployeeHandler()
        {
            
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken ct)
        {
            

            return true;
        }
    }
}
