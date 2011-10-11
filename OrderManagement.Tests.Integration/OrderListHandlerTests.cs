using System;
using System.Net;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;
using OrderManagement.Infrastructure;

namespace OrderManagement.Tests.Integration
{
    [TestFixture]
    public class OrderListHandlerTests
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
        public void OrderList_Get_ShouldReturnStatusCodeOK()
        {
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri("http://localhost/order"), HttpMethod = "GET"};
           
            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            Assert.AreEqual((int)HttpStatusCode.OK, response.StatusCode);
        }


        [Test]
        public void Get_WhenHasPostedOrder_ShouldReturnOneOrderPreview()
        {
            PostOrder();
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            var resultFromJson = Utils.GetResultFromJson(response);
            Assert.AreEqual(1, resultFromJson.Count);
        }


        [Test]
        public void Get_WhenHasPostedOrder_ShouldReturnOrderPreviewWithUri()
        {
            var postOrderResponse = PostOrder();
            var inMemoryRequest = new InMemoryRequest { Uri = new Uri("http://localhost/order"), HttpMethod = "GET" };

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);

            var resultFromJson = Utils.GetResultFromJson(response);
            Assert.AreEqual(postOrderResponse.Headers["location"], resultFromJson[0].uri.Value);
        }


        [Test]
        public void Post_WithOrder_ShouldReturnStatusCodeCreated()
        {
            var response = PostOrder();

            Assert.AreEqual((int)HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public void Post_WithOrder_ShouldReturnLocationHeader()
        {
            var response = PostOrder();

            Assert.IsNotNull(response.Headers["location"]);
        }

        private IResponse PostOrder()
        {
            var inMemoryRequest = new InMemoryRequest {Uri = new Uri("http://localhost/order"), HttpMethod = "POST"};
            var jsonFromObject = Utils.GetJsonFromObject(new {customer = "eirik"});
            inMemoryRequest.Entity = Utils.GetHttpEntity(inMemoryRequest, jsonFromObject, MediaType.Json);

            var response = _inMemoryHost.ProcessRequest(inMemoryRequest);
            return response;
        }
    }
}