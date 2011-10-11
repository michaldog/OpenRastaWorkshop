using System.Collections.Generic;
using System.Linq;
using OrderManagement.Resources;

namespace OrderManagement.Infrastructure
{
    public class Database : IDatabase
    {
        private static List<Order> Orders = new List<Order>();
        private static int NextOrderId;

        public static void ResetDatabase()
        {
            Orders.Clear();
            NextOrderId = 0;
        }

        public void Store(Order order)
        {
            order.Id = NextOrderId++;
            Orders.Add(order);
        }

        public Order GetOrder(int id)
        {
            return Orders.SingleOrDefault(o => o.Id == id);
        }

        public void Remove(Order order)
        {
            Orders.Remove(order);
        }
    }
}