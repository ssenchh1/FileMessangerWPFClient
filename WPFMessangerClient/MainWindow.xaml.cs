using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32.SafeHandles;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPFMessangerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string ip = string.Empty;
        public static int port = 8005;
        public MainWindow()
        {
            InitializeComponent();
            greetingtextblock.Text = "Hello";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new WindowIP();
            this.Close();
            window.Show();
        }
    }
}
