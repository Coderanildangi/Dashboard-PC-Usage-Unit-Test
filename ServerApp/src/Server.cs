using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// This class establishes server on Given IP address.
/// 


namespace ServerApp.src
{
    public class Server
    {
        // Default Constructor.
        public Server() { }

        // Method to Start Server.
        public static bool startServer()
        {
            try
            {
                // Creating Server at Current Machine IP address.
                TcpListener listener = new TcpListener(IPAddress.Any, mPort);

                // Staring the Server.
                listener.Start();

                if(mCount == 0)
                {
                    Console.WriteLine("Server Started... \nWaiting for clients Connections...");

                }

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();

                    // Adding Client IP Address in HashSet.
                    mClientIPAddresses.Add(clientIP);

                    // Starting Client Thread.
                    Thread clientThread = new Thread(() => ClientHandler.handleClient(client));
                    clientThread.Start();
                    return true;
                    printIPsOfClientSystems();

                }
                

            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Method to Print IP Addresses of all Connected Clients.
        public static void printIPsOfClientSystems()
        {
            Console.WriteLine("Connected Clients are : ");
            Console.WriteLine("--------------------------------------------------");
            int i = 1;
            foreach (var item in mClientIPAddresses)
            {
                Console.WriteLine($"{i}. {item.ToString()}");
                i++;
            }
            Console.WriteLine("--------------------------------------------------");
        }

        // ----------------------------------------
        // Private Members
        private const int mPort = 8080;

        // Static member.
        private static int mCount = 0;

        // HashSet of IP address.
        private static HashSet<string> mClientIPAddresses = new HashSet<string>();
    }
}
