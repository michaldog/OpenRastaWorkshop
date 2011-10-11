using OpenRasta.Web;
using OrderManagement.Resources;

namespace OrderManagement.Handlers
{
    public class OrderListHandler
    {
        public OperationResult Get()
        {
            return new OperationResult.OK();
        }

        public OperationResult Post(Order order)
        {
            return new OperationResult.Created{RedirectLocation = order.CreateUri()};

        }
    }
}