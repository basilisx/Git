using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    class Program
    {
        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;
                    byte[] msg2;
                    int bytesSent;
                    bool connected = true;
                    int enemyTurn;
                    Random rng = new Random();
                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        while (connected == true)
                        {
                            Console.WriteLine("Acception");
                            bytes = new byte[1024];
                            int bytesRec = handler.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                            if (data.IndexOf("hey") > -1)
                            {
                                Console.WriteLine("Text received : {0}", data);
                                enemyTurn = rng.Next(1,4);
                                switch (enemyTurn)
                                {
                                    case 1:
                                        msg2 = Encoding.ASCII.GetBytes("attack");
                                        bytesSent = handler.Send(msg2);
                                        break;
                                    case 2:
                                        msg2 = Encoding.ASCII.GetBytes("magic");
                                        bytesSent = handler.Send(msg2);
                                        break;
                                    case 3:
                                        msg2 = Encoding.ASCII.GetBytes("shield");
                                        bytesSent = handler.Send(msg2);
                                        break;
                                }

                                
                            }

                            else if (data.IndexOf("ok") == -1)
                            {
                                connected = false;
                            }

                            data = null;
                        }

                        break;
                    }

                    // Echo the data back to the client.  
                    //byte[] msg = Encoding.ASCII.GetBytes(data);

                    //handler.Send(msg);
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }
       

        public static int Main(string[] args)
        {
            StartListening();
            return 0;
        }
    }
}
