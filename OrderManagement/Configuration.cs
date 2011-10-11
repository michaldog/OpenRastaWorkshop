using OpenRasta.Configuration;
using OpenRasta.DI;
using OrderManagement.Handlers;
using OrderManagement.Infrastructure;
using OrderManagement.Resources;

namespace OrderManagement
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Uses.CustomDependency<IDatabase, Database>(DependencyLifetime.Transient);

                ResourceSpace.Has
                    .ResourcesOfType<Order>()
                    .AtUri("/order/{id}")
                    .HandledBy<OrderHandler>()
                    .AsJsonDataContract();

                ResourceSpace.Has
                    .ResourcesOfType<OrderPreview[]>()
                    .AtUri("/order")
                    .HandledBy<OrderListHandler>()
                    .AsJsonDataContract();
            }
        }
    }
}