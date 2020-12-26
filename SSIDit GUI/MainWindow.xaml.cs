using SSIDit_GUI.Core;
using SSIDit_GUI.Models;
using SSIDit_GUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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

namespace SSIDit_GUI
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;

        public MainWindow()
        {
            InitializeComponent();
            main = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;

            PushSSIDs();

            SetView(new Login());
        }

        public async void PushSSIDs()
        {
            var accessPointList = await AccessPoint.GetSignalOfNetworks();

            foreach (var accessPoint in accessPointList)
                API.Get<SSID>("ssid/new", $"name={accessPoint.SSID}");
        }

        public void SetView(Page page) => MainFrame.Navigate(page);
    }
}
