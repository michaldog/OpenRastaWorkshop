using OpenRasta.Web;
using OrderManagement.Infrastructure;
using OrderManagement.Resources;

namespace OrderManagement.Handlers
{
    public class OrderListHandler
    {
        private readonly IDatabase _database;

        public OrderListHandler(IDatabase database)
        {
            _database = database;
        }

        public OperationResult Get()
        {
            return new OperationResult.OK();
        }

        public OperationResult Post(Order order)
        {
            _database.Store(order);

            return new OperationResult.Created{RedirectLocation = order.CreateUri()};

        }
    }
}