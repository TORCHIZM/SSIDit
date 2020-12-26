using Newtonsoft.Json;
using SSIDit_GUI.Core;
using SSIDit_GUI.CustomElements;
using SSIDit_GUI.Models;
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

namespace SSIDit_GUI.Views
{
    /// <summary>
    /// MainMenu.xaml etkileşim mantığı
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            WelcomeText.Text = $"Welcome, {Utils.Username}!";
            var ssidList = await API.Get<List<SSID>>("ssid/feed");
            BuildSSIDs(ssidList);
        }

        private void BuildSSIDs(List<SSID> ssidList)
        {
            SSIDViewList.Children.Clear();
            
            foreach (var ssid in ssidList)
                SSIDViewList.Children.Add(new SSIDBox(ssid));
        }

        private async void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ssidList = new List<SSID>();
            var sortedList = new List<SSID>();

            switch (SortBox.SelectedIndex)
            {
                case 0:
                    ssidList = await API.Get<List<SSID>>("ssid/feed");
                    BuildSSIDs(ssidList);
                    break;
                case 1:
                    ssidList = await API.Get<List<SSID>>("ssid/feed");

                    sortedList = ssidList.OrderBy(o => o.Votes.Where(x => x.Type == 1).ToList().Count).ToList();
                    sortedList.Reverse();

                    BuildSSIDs(sortedList);
                    break;
                case 2:
                    ssidList = await API.Get<List<SSID>>("ssid/feed");

                    sortedList = ssidList.OrderBy(o => o.Votes.Where(x => x.Type == 0).ToList().Count).ToList();
                    sortedList.Reverse();

                    BuildSSIDs(sortedList);
                    break;
                default:
                    ssidList = await API.Get<List<SSID>>("ssid/feed");
                    BuildSSIDs(ssidList);
                    break;
            }
        }
    }
}
