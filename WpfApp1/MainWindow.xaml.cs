using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebClient _WebClient1;
        private WebClient _WebClient2;
        private WebClient _WebClient3;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _WebClient1 = new WebClient();
            _WebClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            _WebClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            _WebClient1.DownloadFileAsync(new Uri("http://akinstall.plaync.com/mxm/rc/install/20160607/MXM_RC.7z.001"), @"D:\Downloads\LauncherDownloads\TestDownload\" + "MXM_RC.7z.001");

            _WebClient2 = new WebClient();
            _WebClient2.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed2);
            _WebClient2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged2);
            _WebClient2.DownloadFileAsync(new Uri("http://rc.up4rep.plaync.co.kr/INSTALL/LE_RC/LEClient.msi"), @"D:\Downloads\LauncherDownloads\TestDownload\" + "LEClient.msi");

            _WebClient3 = new WebClient();
            _WebClient3.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed3);
            _WebClient3.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged3);
            _WebClient3.DownloadFileAsync(new Uri("http://common-ncetc.ktics.co.kr/common/RC/BNS_KOR_RC/2016120201/setup.exe"), @"D:\Downloads\LauncherDownloads\TestDownload\" + "setup.exe");
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

        private void ProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void Completed2(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }


        private void ProgressChanged3(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar3.Value = e.ProgressPercentage;
        }

        private void Completed3(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(_WebClient1 != null)
                _WebClient1.CancelAsync();

            if (_WebClient2 != null)
                _WebClient2.CancelAsync();

            if (_WebClient3 != null)
                _WebClient3.CancelAsync();
        }
    }
}
