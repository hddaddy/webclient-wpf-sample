using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stopwatch sw = new Stopwatch();

        private WebClient _WebClient1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _WebClient1 = new WebClient();
            _WebClient1.DownloadFileCompleted += Completed;
            _WebClient1.DownloadProgressChanged += ProgressChanged;
            //_WebClient1.DownloadFileAsync(new Uri("http://akinstall.plaync.com/mxm/rc/install/20160607/MXM_RC.7z.001"),
            //    @"D:\Downloads\LauncherDownloads\TestDownload\" + "MXM_RC.7z.001");
            sw.Reset();
            sw.Start();
            _WebClient1.DownloadFileAsync(new Uri("http://rc.up4rep.plaync.co.kr/INSTALL/LE_RC/LEClient.msi"),
                @"D:\Downloads\LauncherDownloads\TestDownload\" + "LEClient.msi");

            //_WebClient1.DownloadFileAsync(
            //    new Uri("http://common-ncetc.ktics.co.kr/common/RC/BNS_KOR_RC/2016120201/Data19.cab"),
            //    @"D:\Downloads\LauncherDownloads\TestDownload\" + "Data19.cab");
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            sw.Stop();
            p1text.Text = sw.ElapsedMilliseconds.ToString();

            MessageBox.Show("Download completed!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_WebClient1 != null)
                _WebClient1.CancelAsync();
        }

        private void HttpButton_Click(object sender, RoutedEventArgs e)
        {
            DownloadHttpClient("http://rc.up4rep.plaync.co.kr/INSTALL/LE_RC/LEClient.msi");
            //HttpGetForLargeFileInWrongWay();
        }

        private async void DownloadHttpClient(string webAddress)
        {
            sw.Reset();
            sw.Start();
            //instance of HTTPClient
            var client = new HttpClient();

            //send  request asynchronously
            var response = await client.GetAsync(webAddress);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read response asynchronously and save asynchronously to file
            using (
                var fileStream = new FileStream(@"D:\Downloads\LauncherDownloads\TestDownload\" + "LEClient.msi",
                    FileMode.Create, FileAccess.Write, FileShare.None)
            )
            {
                //copy the content from response to filestream
                await response.Content.CopyToAsync(fileStream);
            }

            sw.Stop();
            p1text.Text = sw.ElapsedMilliseconds.ToString();
        }

        private void DecompressButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}