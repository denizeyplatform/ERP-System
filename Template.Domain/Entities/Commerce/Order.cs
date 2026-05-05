using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Domain.Entities.Commerce
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public short status { get; set; }
        public int? CouponId { get; set; }
        public List<OrderItem> Items { get; set; } = new();
    }
}
