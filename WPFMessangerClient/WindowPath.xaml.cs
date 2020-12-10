using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFMessangerClient
{
    /// <summary>
    /// Логика взаимодействия для WindowPath.xaml
    /// </summary>
    public partial class WindowPath : Window
    {
        public WindowPath()
        {
            InitializeComponent();
            App.path = @$"C:\Users\{Environment.UserName}\Desktop\{App.nameoffile}";
            pathtextblock.Text = App.path;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ext = App.nameoffile.Substring(App.nameoffile.Length - 3);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "7z file (*.7z)|*.7z | mp4 file (*.mp4)|*.mp4 | pdf file (*.pdf)|*.pdf";
            saveFileDialog.InitialDirectory = @$"C:\Users\{Environment.UserName}\Desktop";
            saveFileDialog.FileName = App.nameoffile;
            saveFileDialog.DefaultExt = ext;
            saveFileDialog.AddExtension = true;
            //saveFileDialog.ShowDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                pathtextblock.Text = saveFileDialog.FileName;
                App.path = saveFileDialog.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new WindowProgressBar();

            window.Show();
            this.Close();
        }
    }
}
