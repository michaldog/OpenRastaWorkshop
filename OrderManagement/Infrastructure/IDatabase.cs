using OrderManagement.Resources;

namespace OrderManagement.Infrastructure
{
    public interface IDatabase
    {
        void Store(Order order);
        Order GetOrder(int id);
    }
}