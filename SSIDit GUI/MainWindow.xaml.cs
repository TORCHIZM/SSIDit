using SSIDit_GUI.Core;
using SSIDit_GUI.Models;
using SSIDit_GUI.Views;
using System.Net;
using System.Windows;
using System.Windows.Controls;

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
