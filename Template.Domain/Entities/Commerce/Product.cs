using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;
using static System.Net.Mime.MediaTypeNames;

namespace Template.Domain.Entities.Commerce
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();



    }
}
