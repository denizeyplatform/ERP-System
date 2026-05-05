using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;

namespace Template.Domain.Interfaces.Commerce
{
    public interface IOrderRepository
    {
        Task<object> createOrder(Order order);

        Task<Order> CheckoutAsync();

    }
}
