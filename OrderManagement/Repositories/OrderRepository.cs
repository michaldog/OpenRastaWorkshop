using System.Collections.Generic;
using System.Linq;
using OrderManagement.Resources;

namespace OrderManagement.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static IList<Order> _orders = new List<Order>();

        public void Insert(Order order)
        {
            _orders.Add(order);    
        }

        public void Update(Order order)
        {
            var existingOrder = _orders.SingleOrDefault(x => x.Id == order.Id);
            if (existingOrder != null)
                existingOrder = order;
        }

        public Order Get(long orderId)
        {
            return new Order {Id = 12345}; //_orders.SingleOrDefault(x => x.Id == orderId);}
        }
    }
}