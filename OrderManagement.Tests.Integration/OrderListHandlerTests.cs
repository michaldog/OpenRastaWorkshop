using System;
using System.Net;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;

namespace OrderManagement.Tests.Integration
{
    [TestFixture]
    public class OrderListHandlerTests
    {
        private InMemoryHost _inMemoryHost;

        [SetUp]
        public void SetUp()
        {
            _inMemoryHost = new InMemoryHost(new Configuration());
            DependencyManager.SetResolver(_inMemoryHost.Resolver);
        }

        [Test]
        public void OrderList_Get_ShouldReturnStatusCodeOK()
        {
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri("http://localhost/order"), HttpMethod = "GET"};
           
            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Post_WithOrder_ShouldReturnStatusCodeCreated()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "POST" };
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, "{}", MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public void Post_WithOrder_ShouldReturnLocationHeader()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "POST" };
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, "{}", MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.IsNotNull(response.Headers["location"]);
        }

    }
}