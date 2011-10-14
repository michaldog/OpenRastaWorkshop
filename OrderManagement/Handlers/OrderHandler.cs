using OpenRasta.Web;
using OrderManagement.Infrastructure;
using OrderManagement.Resources;

namespace OrderManagement.Handlers
{
    public class OrderHandler
    {
        private readonly IDatabase _database;

        public OrderHandler(IDatabase database)
        {
            _database = database;
        }

        public OperationResult Get(int id)
        {
            var order = _database.GetOrder(id);

            if (order == null) return new OperationResult.NotFound();

            return new OperationResult.OK(order);
        }

        public OperationResult Put(int id, Order order)
        {
            var orderToUpdate = _database.GetOrder(id);

            if (orderToUpdate == null) return new OperationResult.NotFound();

            orderToUpdate.Update(order.Reference, order.Customer, order.Details);
            return new OperationResult.OK(order);
        }

        public OperationResult Delete(int id)
        {
            var order = _database.GetOrder(id);

            if (order == null) return new OperationResult.NotFound();

            _database.Remove(order);
            return new OperationResult.NoContent();
        }

        public OperationResult Post(Order order)
        {
            _database.Store(order);

            return new OperationResult.Created { RedirectLocation = order.CreateUri(), ResponseResource = order };

        }
    }
}