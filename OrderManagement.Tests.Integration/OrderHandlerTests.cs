using System;
using System.Net;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;
using OrderManagement.Resources;

namespace OrderManagement.Tests.Integration
{
    [TestFixture]
    public class OrderHandlerTests
    {
        private InMemoryHost _inMemoryHost;

        [SetUp]
        public void SetUp()
        {
            _inMemoryHost = new InMemoryHost(new Configuration());
            DependencyManager.SetResolver(_inMemoryHost.Resolver);
        }

        [Test]
        public void Order_Get_ShouldReturnOK()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order/12345"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.That(response.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public void Order_Get_ShouldReturnOrder()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order/12345"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            dynamic resultFromJson = Utils.GetResultFromJson(response);

            Assert.That(resultFromJson.Id.Value, Is.EqualTo(12345));

        }

        [Test]
        public void Order_Post_ShouldReturnStatusCreated()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "POST" };
            var jsonFromObject = Utils.GetJsonFromObject(new Order { Id = 12345 });
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.That(response.StatusCode, Is.EqualTo((int)HttpStatusCode.Created));
        }

        [Test]
        public void Order_Post_ShouldReturnLocation()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "POST" };
            var jsonFromObject = Utils.GetJsonFromObject(new Order { Id = 12345 });
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.That(response.Headers["location"], Is.Not.Null);
        }

        [Test]
        public void Order_Post_ShouldReturnResource()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "POST" };
            var jsonFromObject = Utils.GetJsonFromObject(new Order { Id = 12345 });
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);
            dynamic resultFromJson = Utils.GetResultFromJson(response);

            Assert.That(resultFromJson.Id.Value, Is.EqualTo(12345));
        }

        [Test]
        public void Order_Put_ShouldReturnOK()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "PUT" };
            var jsonFromObject = Utils.GetJsonFromObject(new Order {Id = 12345, Name = "test"});
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.That(response.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        }
    }
}