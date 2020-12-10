using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;

namespace WPFMessangerClient
{
    /// <summary>
    /// Логика взаимодействия для WindowIP.xaml
    /// </summary>
    public partial class WindowIP : Window
    {
        public WindowIP()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.ip = textbox.Text;
            try
            {
                App.tcpClient = new TcpClient();
                //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(App.ip).MapToIPv4(), App.port);
                App.tcpClient.Connect(IPAddress.Parse(textbox.Text),App.port);
                var stream = App.tcpClient.GetStream();

                byte[] datalength = new byte[8];
                var bytes = stream.Read(datalength, 0, 8);
                App.bytesleft = BitConverter.ToInt64(datalength, 0);

                byte[] filenamelength = new byte[4];
                stream.Read(filenamelength, 0, 4);
                var namelength = BitConverter.ToInt32(filenamelength, 0);

                byte[] name = new byte[namelength];
                stream.Read(name, 0, namelength);
                App.nameoffile = Encoding.UTF8.GetString(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                
            }
            


            Window window = new WindowPath();
            this.Close();
            window.Show();
        }
    }
}
