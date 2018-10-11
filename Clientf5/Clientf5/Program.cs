using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clientf5
{ 
    class Program
    {
    private const int FUFFER_SIZE = 1024;
    private const int PORT_NUMBER = 9999;
       // static UserEncoding encoding = new UserEncoding();
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                //1- Connect
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();
                Console.WriteLine("Connected to Serverf5");
                Console.WriteLine("Enter your name:");
                string str = Console.ReadLine();
                //2- Send

                byte[] data = Encoding.Default.GetBytes(str);
                stream.Write(data, 0, data.Length);
                //3- Receive
                data = new byte[FUFFER_SIZE];
                stream.Read(data, 0, FUFFER_SIZE);
                Console.WriteLine(Encoding.Default.GetString(data));
                //4- Close
                stream.Close();
                client.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("Error "+ e.Message);
            }
            Console.ReadKey();
        }
    }
}
