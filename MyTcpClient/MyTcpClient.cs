using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MyTcpClient
{
    class MyTcpClient
    {
        static void Main(string[] args)
        {
            var client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("16.54.177.43"), 8091));
            Console.WriteLine("Client started!");
            var stream = client.GetStream();
            var request = "Hello Worl! This is my first TCP socket program. Thanks you!!";
            var requestBuff = Encoding.UTF8.GetBytes(request);
            stream.Write(requestBuff, 0, requestBuff.Length);
            stream.Flush();
            var response = new byte[1024];
            var length = stream.Read(response, 0, response.Length);
            Console.WriteLine("Response was received: {0}", Encoding.UTF8.GetString(response, 0, length));
            client.Close();
            Console.WriteLine("DONE");
            Console.ReadLine();
        }
    }
}
