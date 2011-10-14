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
                    .ResourcesOfType<OrderPreview[]>()
                    .AtUri("/orders")
                    .HandledBy<OrderListHandler>()
                    .AsJsonDataContract();
            }
        }
    }
}