using System;
using OpenRasta.Web;
using OrderManagement.Repositories;
using OrderManagement.Resources;

namespace OrderManagement.Handlers
{
    public class OrderHandler
    {
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OperationResult Get(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            return new OperationResult.OK {ResponseResource = order};
        }

        public OperationResult Post(Order order)
        {
            _orderRepository.Insert(order);
            return new OperationResult.Created { ResponseResource = order, RedirectLocation = order.CreateUri() };
        }

        public OperationResult Put(Order order)
        {
            _orderRepository.Update(order);
            return new OperationResult.OK();
        }
    }
}