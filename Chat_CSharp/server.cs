using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Chat_CSharp_Server
{
    class Server
    {

        public static Socket ServerConnection()
        {
            Console.OutputEncoding = Encoding.UTF8;

            byte[] data = new byte[1024];

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            newsock.Bind(ipep);

            newsock.Listen(10);

            Console.WriteLine("En attente du client");

            Socket client = newsock.Accept();

            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

            string welcome = "Bienvenue sur le serveur de test";

            data = Encoding.UTF8.GetBytes(welcome);

            client.Send(data, data.Length, SocketFlags.None);

            return client;
        }

        public static void sendMsg(Socket client)
        {
            string input = Console.ReadLine();

            Console.WriteLine("Vous: " + input);

            client.Send(Encoding.UTF8.GetBytes(input));
        }

        public static void receiveMsg(Socket client)
        {
            byte[] data = new byte[1024];

            data = new byte[1024];

            int recv = client.Receive(data);

            Console.WriteLine("Client: " + Encoding.UTF8.GetString(data, 0, recv));
        }
        static void Main(string[] args)
        {
            Socket client = ServerConnection();
            


        }
        


    }
}