using OpenRasta.Web;
using OrderManagement.Infrastructure;

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
    }
}