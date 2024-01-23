using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using ServerApp.src;

namespace Server_UnitTest
{
    [TestClass]
    public class DataBaseHandler_UnitTest
    {
        private const string TestDbConnectionString = @"Server=DESKTOP-9UFDCFP;Database=ClientDataDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;Integrated Security=True;";

        [TestInitialize]
        public void Initialize()
        {
            // Set up the test database
            using (SqlConnection connection = new SqlConnection(TestDbConnectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS ClientSystemDataTest (
                        IPAddress NVARCHAR(15),
                        MachineName NVARCHAR(50),
                        OS NVARCHAR(50),
                        CPU NVARCHAR(50),
                        RAM NVARCHAR(50),
                        GPU NVARCHAR(50),
                        DISK NVARCHAR(50),
                        CPUUsage FLOAT,
                        RAMUsage FLOAT,
                        DiskUsage FLOAT,
                        FanSpeed FLOAT,
                        IsConnected BIT,
                        GPULoad FLOAT,
                        GPUTemp FLOAT
                    )";
                SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
                createTableCommand.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public void TestSaveOrUpdateData()
        {
            // Arrange
            var ipAddress = "192.168.1.1";
            var machineName = "TestMachine";
            var os = "TestOS";
            var cpu = "TestCPU";
            var ram = "TestRAM";
            var gpu = "TestGPU";
            var disk = "TestDisk";
            var cpuUsage = 50.0f;
            var ramUsage = 60.0f;
            var diskUsage = 70.0f;
            var fanSpeed = 80.0f;
            var gpuUsage = 90.0f;
            var gpuTemp = 75.0f;
            var isConnected = true;

            // Act
            DataBaseHandler.saveOrUpdateData(ipAddress, machineName, os, cpu, ram, gpu, disk, cpuUsage, ramUsage, diskUsage, fanSpeed, gpuUsage, gpuTemp, isConnected);

            // Assert
            using (SqlConnection connection = new SqlConnection(TestDbConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM ClientSystemDataTest WHERE IPAddress = @IPAddress";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@IPAddress", ipAddress);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    Assert.IsTrue(reader.Read());
                    Assert.AreEqual(machineName, reader["MachineName"].ToString());
                    Assert.AreEqual(os, reader["OS"].ToString());
                    Assert.AreEqual(cpu, reader["CPU"].ToString());
                    Assert.AreEqual(ram, reader["RAM"].ToString());
                    Assert.AreEqual(gpu, reader["GPU"].ToString());
                    Assert.AreEqual(disk, reader["DISK"].ToString());
                    Assert.AreEqual(cpuUsage, (float)reader["CPUUsage"], 0.01);
                    Assert.AreEqual(ramUsage, (float)reader["RAMUsage"], 0.01);
                    Assert.AreEqual(diskUsage, (float)reader["DiskUsage"], 0.01);
                    Assert.AreEqual(fanSpeed, (float)reader["FanSpeed"], 0.01);
                    Assert.AreEqual(isConnected, (bool)reader["IsConnected"]);
                    Assert.AreEqual(gpuUsage, (float)reader["GPULoad"], 0.01);
                    Assert.AreEqual(gpuTemp, (float)reader["GPUTemp"], 0.01);
                }
            }
        }
    }
}
