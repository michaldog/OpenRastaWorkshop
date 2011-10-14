using System;
using System.Net;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;

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

        
        
    }
}