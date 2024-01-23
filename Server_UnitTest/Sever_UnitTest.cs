using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerApp.src;
using System;
using System.Net.Sockets;
using System.Net;

namespace ServerApp_UnitTest
{
    [TestClass]
    public class Sever_UnitTest
    {
        // Test to check if server is established and Clients are connected.
        [TestMethod]
        public void TestStartServer_SuccessfulConnection()
        {
            // Act.
            var result = Server.startServer();

            // Assert.
            Assert.AreEqual(true,result);
        }

        //
    }
}
