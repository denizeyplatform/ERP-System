using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.CQRS.Command;

namespace Template.Application.CQRS.Handler.Commands
{
    public class DeleteEmployeeHandler
    : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        

        public DeleteEmployeeHandler()
        {
           
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken ct)
        {
            

            return true;
        }
    }
}
