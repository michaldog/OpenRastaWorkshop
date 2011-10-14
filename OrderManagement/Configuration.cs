using OpenRasta.Configuration;
using OpenRasta.DI;
using OrderManagement.Handlers;
using OrderManagement.Repositories;
using OrderManagement.Resources;

namespace OrderManagement
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {

                ResourceSpace.Has
                    .ResourcesOfType<OrderPreview[]>()
                    .AtUri("/orders")
                    .HandledBy<OrderListHandler>()
                    .AsJsonDataContract();

                ResourceSpace.Has
                    .ResourcesOfType<Order>()
                    .AtUri("/order")
                    .And.AtUri("/order/{orderId}")
                    .HandledBy<OrderHandler>()
                    .AsJsonDataContract();

                ResourceSpace.Uses
                    .CustomDependency<IOrderRepository, OrderRepository>(DependencyLifetime.Singleton);
            }
        }
    }
}