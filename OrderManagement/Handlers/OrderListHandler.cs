using System;
using OpenRasta.Web;
using OrderManagement.Resources;

namespace OrderManagement.Handlers
{
    public class OrderListHandler
    {
        public OperationResult Get()
        {
            var orderPreviews = new[] {new OrderPreview {Id = 12345}};

            return new OperationResult.OK {ResponseResource = orderPreviews};
        }
    }
}