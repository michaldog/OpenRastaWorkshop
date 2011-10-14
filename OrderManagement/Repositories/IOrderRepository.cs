using OrderManagement.Resources;

namespace OrderManagement.Repositories
{
    public interface IOrderRepository
    {
        void Insert(Order order);
        Order Get(long orderId);
        void Update(Order order);
    }
}