using System;
using System.Runtime.Serialization;

namespace OrderManagement.Resources
{
    [DataContract(Name = "orderPreview")]
    public class OrderPreview
    {
        public OrderPreview(Uri uri)
        {
            Uri = uri.AbsoluteUri;
        }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }
}