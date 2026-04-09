using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces;

namespace Template.Domain.Common
{
    public abstract class AggregateRoot : BaseEntity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void AddDomainEvent(IDomainEvent eventItem)
            => _domainEvents.Add(eventItem);

        public void ClearDomainEvents()
            => _domainEvents.Clear();
    }
}
