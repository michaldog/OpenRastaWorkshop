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
            var orders = _database.GetAllOrders().Select(o => new OrderPreview(o));
            
            return new OperationResult.OK(orders.ToArray());
        }

        
    }
}