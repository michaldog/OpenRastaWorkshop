using OpenRasta.Configuration;
using OrderManagement.Handlers;
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
                    .ResourcesOfType<Order>()
                    .AtUri("/order/{id}")
                    .HandledBy<OrderHandler>()
                    .AsJsonDataContract();

                ResourceSpace.Has
                    .ResourcesOfType<Order[]>()
                    .AtUri("/order")
                    .HandledBy<OrderListHandler>()
                    .AsJsonDataContract();
            }
        }
    }
}