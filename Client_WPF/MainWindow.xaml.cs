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
        public MainWindow()
        {
            InitializeComponent();

            string test = "Sauvegarde 1";
            string test2 = "Sauvegarde 2";
            string test3 = "Sauvegarde 3";
            string test4 = "Sauvegarde 4";

            SavesList.Items.Add(test);
            SavesList.Items.Add(test2);
            SavesList.Items.Add(test3);
            SavesList.Items.Add(test4);
        }
    }
}
