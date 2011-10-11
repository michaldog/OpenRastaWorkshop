using System;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using OpenRasta.DI;
using OpenRasta.Hosting.InMemory;
using OpenRasta.Web;

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

        
    }
}