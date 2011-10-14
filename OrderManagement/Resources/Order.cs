using System.Runtime.Serialization;

namespace OrderManagement.Resources
{
    [DataContract(Name = "order")]
    public class Order
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "customer")]
        public string Customer { get; private set; }

        [DataMember(Name = "details")]
        public string Details { get; private set; }

        public void Update(string reference, string customer, string details)
        {
            Reference = reference;
            Customer = customer;
            Details = details;
        }
    }
}