using System;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;
using OrderManagement.Infrastructure;

namespace OrderManagement.Tests.Integration
{
    [TestFixture]
    public class OrderHandlerTests
    {
        private InMemoryHost _inMemoryHost;

        [SetUp]
        public void SetUp()
        {
            Database.ResetDatabase();
            _inMemoryHost = new InMemoryHost(new Configuration());
            DependencyManager.SetResolver(_inMemoryHost.Resolver);
        }


        [Test]
        public void Get_WhenHasPostedOrder_ShoulReturnStatusCodeOK()
        {
            var orderUri = PostOrder();
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri(orderUri), HttpMethod = "GET"};

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }


        [Test]
        public void Get_WhenHasPostedOrderWithCustomerEirik_ShoulReturnOrderWithCustomerEirik()
        {
            var orderUri = PostOrder();
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri(orderUri), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            var json = Utils.GetResultFromJson(response);
            Assert.AreEqual("eirik", json.customer.Value);
        }


        [Test]
        public void Get_WhenHasNotPostedOrder_ShouldReturnStatusCodeNotFound()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order/1"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.NotFound, response.StatusCode);
        }


        [Test]
        public void Put_WhenHasPostedOrder_ShouldReturnStatusCodeOK()
        {
            var orderUri = PostOrder();

            var response = PutOrder(orderUri, new {customer = "torstein"});

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Put_WhenHasPostedOrder_ShouldReturnStatusCodeNotFound()
        {
            var response = PutOrder("http://localhost/order/1", new { customer = "torstein" });

            Assert.AreEqual((int)HttpStatusCode.NotFound, response.StatusCode);
        }


        [Test]
        public void Put_WhenHasPostedOrder_ShouldReturnUpdatedOrder()
        {
            var orderUri = PostOrder();

            var response = PutOrder(orderUri, new { customer = "torstein" });

            var json = Utils.GetResultFromJson(response);
            Assert.AreEqual("torstein", json.customer.Value);
        }

        [Test]
        public void Get_WhenHasPuttedOrder_ShouldReturnUpdatedOrder()
        {
            var orderUri = PostOrder();
            PutOrder(orderUri, new {customer = "torstein"});
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri(orderUri), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            var json = Utils.GetResultFromJson(response);
            Assert.AreEqual("torstein", json.customer.Value);

        }


        [Test]
        public void Delete_WhenHasPostedOrder_ShouldReturnStatusCodeNoContent()
        {
            var orderUri = PostOrder();
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri(orderUri), HttpMethod = "DELETE" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.NoContent, response.StatusCode);
        }


        [Test]
        public void Delete_WhenHasNotPostedOrder_ShouldReturnStatusCodeNotFound()
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order/1"), HttpMethod = "DELETE" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.NotFound, response.StatusCode);
        }


        [Test]
        public void Get_WhenHasDeletedOrder_ShouldReturnStatusCodeNotFound()
        {
            var orderUri = PostOrder();
            _inMemoryHost.ProcessRequest(new InMemoryRequest { Uri = new Uri(orderUri), HttpMethod = "DELETE" });
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri(orderUri), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.NotFound, response.StatusCode);
        }


        private string PostOrder()
        {
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri("http://localhost/order"), HttpMethod = "POST"};
            var jsonFromObject = Utils.GetJsonFromObject(new {customer = "eirik"});
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            return response.Headers["location"];
        }

        private IResponse PutOrder(string location, dynamic updatedOrder)
        {
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri(location), HttpMethod = "PUT" };
            var jsonFromObject = Utils.GetJsonFromObject(updatedOrder);
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            return response;
        }
        
    }
}