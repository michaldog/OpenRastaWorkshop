using OpenRasta.Web;
using OrderManagement.Infrastructure;
using OrderManagement.Resources;
using System.Linq;

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
            var orderPreviews = _database.GetAllOrders().Select(o => new OrderPreview(o.CreateUri()));

            return new OperationResult.OK(orderPreviews.ToArray());
        }

        public OperationResult Post(Order order)
        {
            _database.Store(order);

            return new OperationResult.Created{RedirectLocation = order.CreateUri()};

        }
    }
}