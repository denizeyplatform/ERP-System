using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get;  set; }

        public DateTime? ModifiedAt { get;  set; }
        public string? ModifiedBy { get;  set; }

        public bool IsDeleted { get; protected set; }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
