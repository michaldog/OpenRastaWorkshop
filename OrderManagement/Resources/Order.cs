using System.Runtime.Serialization;

namespace OrderManagement.Resources
{
    [DataContract(Name = "order")]
    public class Order
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "customer")]
        public string Customer { get; set; }
    }
}