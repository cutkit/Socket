using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Serverf5
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;
        ///static UserEncoding encoding = new UserEncoding();
        static void Main(string[] args)
        {
            try
            {
            
                while (true)
                {
                    IPAddress address = IPAddress.Parse("127.0.0.1");
                    TcpListener listener = new TcpListener(address, PORT_NUMBER);
                    //1- Listen
                    listener.Start();
                    Console.WriteLine("Server start on " + listener.LocalEndpoint);
                    Socket socket = listener.AcceptSocket();
                    Console.WriteLine("connection received from" + socket.RemoteEndPoint);
                    //2- Received
                    byte[] data = new byte[BUFFER_SIZE];
                    socket.Receive(data);
                    string str = Encoding.Default.GetString(data);
                    //3- Send
                    socket.Send(Encoding.Default.GetBytes("Got Heap Server Receive " + "Server Xin Chao Ban " + str));
                    //4- Close
                    socket.Close();
                    listener.Stop();
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
                
            }

            Console.ReadKey();

        }
    }
}
