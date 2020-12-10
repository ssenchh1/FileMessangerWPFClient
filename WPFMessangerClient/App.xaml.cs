using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace WPFMessangerClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string ip;
        public static int port = 8005;
        public static string path;
        public static TcpClient tcpClient;
        public static long bytesleft;
        public static string nameoffile;
    }
}
