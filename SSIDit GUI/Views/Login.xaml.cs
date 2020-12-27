using SSIDit_GUI.Core;
using System.Windows;
using System.Windows.Controls;

namespace SSIDit_GUI.Views
{
    /// <summary>
    /// Login.xaml etkileşim mantığı
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Utils.Username = UsernameBox.Text;
            Utils.ID = int.Parse(IDBox.Text);
            MainWindow.main.SetView(new MainMenu());
        }
    }
}
