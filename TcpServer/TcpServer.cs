using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpServer
{
    class TcpServer
    {
        static void Main(string[] args)
        {
            var port = 8091;
            TcpListener listener = new TcpListener(IPAddress.Parse("16.54.177.43"), port);
            listener.Start();
            Console.WriteLine("TCP Listener started on port {0}", port);
            var buff = new byte[256];
            try
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!!");
                var stream = client.GetStream();
                int i = 0;
                Console.WriteLine("Received data:");
                while ((i = stream.Read(buff, 0, buff.Length)) != 0)
                {
                    var data = Encoding.UTF8.GetString(buff, 0, i);
                    Console.Write(data);
                    i = 0;
                    var response = Encoding.UTF8.GetBytes("Thank you!!");
                    stream.Write(response, 0, response.Length);
                }
                client.Close();
            }
            finally
            {
                listener.Stop();
            }
            Console.WriteLine("DONE");
            Console.ReadLine();

        }
    }
}
