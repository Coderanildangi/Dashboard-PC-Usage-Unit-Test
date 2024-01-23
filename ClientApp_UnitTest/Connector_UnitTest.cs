using ClientApp.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Net.Sockets;

namespace ClientApp_UnitTest
{
    [TestClass]
    public class Connector_UnitTest
    {
        // Unit Test for checking successful connection with ServerApp.
        [TestMethod]
        public void TestSendDataToServer_SuccessfulConnection()
        {
            /// Arrange
            // Creating object of Connector class.
            Connector connector = new Connector();

            // Act
            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                connector.sendDataToServer("Machine", "OS", "CPU", "RAM", "GPU", "Disk", 100.0f, 60.0f, 70.0f, 1200.0f, 90.0f, 75.0f);

                // Assert
                string consoleOutput = sw.ToString();
                Assert.IsTrue(consoleOutput.Contains("Client Successfully Connected"));
            }

        }

        // Unit Test for checking Exception handling for not working connection.
        [TestMethod]
        public void TestSendDataToServer_ExceptionHandling()
        {
            // Arrange
            Connector connector = new Connector();

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Pass invalid server IP or port to intentionally cause an exception
                connector.sendDataToServer("InvalidIP", "OS", "CPU", "RAM", "GPU", "Disk", 50.0f, 60.0f, 70.0f, 80.0f, 90.0f, 75.0f);

                // Assert
                string consoleOutput = sw.ToString();
                Assert.IsTrue(consoleOutput.Contains("No connection could be made because the target machine actively refused it 192.168.0.129:8080"));
            }
        }
    }
}
