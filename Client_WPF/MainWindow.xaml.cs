using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace Client_WPF
{
    public partial class MainWindow : Window
    {
        public Socket server;
        public MainWindow()
        {
            InitializeComponent();

            server = Connection();

            //Mysocket();
            //Console.OutputEncoding = Encoding.UTF8;
        }

        private Socket Connection()
        {
            byte[] data = new byte[1024];

            string stringData;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);

            }
            catch (SocketException e)
            {
                MessageBox.Show("Unable to connect to server.");

                MessageBox.Show(e.ToString());

            }

            int recv = server.Receive(data);

            stringData = Encoding.UTF8.GetString(data, 0, recv);

            MessageBox.Show(stringData);

            return server;
        }

        private void sendMsg(string input)
        {
            server.Send(Encoding.UTF8.GetBytes(input));
        }

        private void receiveMsg(Socket server)
        {
            byte[] data = new byte[1024];
            string stringData;

            data = new byte[1024];

            int recv = server.Receive(data);

            recv = server.Receive(data);

            stringData = Encoding.UTF8.GetString(data, 0, recv);

            byte[] utf8string = System.Text.Encoding.UTF8.GetBytes(stringData);

            MessageBox.Show("Server: " + stringData);
        }

        private void receiveData()
        {

        }

           
    }
}
