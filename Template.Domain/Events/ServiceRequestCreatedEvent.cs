using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces;

namespace Template.Domain.Events
{
    public record ServiceRequestCreatedEvent(Guid Id) : IDomainEvent;
}
