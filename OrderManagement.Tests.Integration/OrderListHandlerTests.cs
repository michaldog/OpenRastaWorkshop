using System;
using System.Net;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;
using OrderManagement.Handlers;
using OrderManagement.Resources;

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
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri("http://localhost/orders"), HttpMethod = "GET"};
           
            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void OrderList_Get_ShouldReturnOrderPreviews()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/orders"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            dynamic resultFromJson = Utils.GetResultFromJson(response);

            Assert.That(resultFromJson[0].id.Value, Is.EqualTo(12345));
        }

    }
}