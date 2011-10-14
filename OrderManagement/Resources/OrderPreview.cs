using System;
using System.Runtime.Serialization;
using OpenRasta.Web;

namespace OrderManagement.Resources
{
    [DataContract(Name = "orderPreview")]
    public class OrderPreview
    {
        public OrderPreview(Order order)
        {
            Id = order.Id;
            Reference = order.Reference;
            Uri = order.CreateUri().AbsoluteUri;
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }
}