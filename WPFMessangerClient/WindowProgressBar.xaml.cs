using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Логика взаимодействия для WindowProgressBar.xaml
    /// </summary>
    public partial class WindowProgressBar : Window, INotifyPropertyChanged
    {
        private int buffersize = 1024;

        public BackgroundWorker _bgWorker = new BackgroundWorker();

        private int _workerrState;

        public int WorkerState
        { get { return _workerrState; } 
          set 
          {
                _workerrState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Worker state"));
          } 
        }

        public WindowProgressBar()
        {
            InitializeComponent();

            DataContext = this;

            
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
            _bgWorker.WorkerReportsProgress = true;

            _bgWorker.DoWork += _bgWorker_DoWork;
            _bgWorker.ProgressChanged += worker_progressChanged;
            _bgWorker.RunWorkerAsync();

            
        }

        private void worker_progressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb1.Value += e.ProgressPercentage;
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var stream = App.tcpClient.GetStream();

            var numberofpackages = App.bytesleft / buffersize;
            byte[] buffer = new byte[buffersize];
            var username = Environment.UserName;

            int bytesread = 0;
            using (FileStream fs = new FileStream(App.path, FileMode.Create))
            {
                while (App.bytesleft > 0)
                {
                    if (stream.DataAvailable)
                    {
                        int nextpacketsize = 0;
                        if (App.bytesleft > buffersize)
                        {
                            nextpacketsize = buffersize;
                        }
                        else
                        {
                            nextpacketsize = (int)App.bytesleft;
                        }

                        var bytred = stream.Read(buffer, 0, nextpacketsize);
                        fs.Write(buffer, 0, bytred);
                        bytesread += bytred;
                        App.bytesleft -= bytred;
                        int percent = (int)((bytesread / buffersize) * 100 / numberofpackages);
                        //Console.WriteLine(percent + "%");

                        var progress = percent - WorkerState;
                        
                        WorkerState = percent;
                        _bgWorker.ReportProgress(progress);
                    }

                }
            }
            MessageBox.Show("Complete");
            stream.Close();
            App.tcpClient.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
