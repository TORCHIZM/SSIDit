using SSIDit_GUI.Core;
using SSIDit_GUI.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SSIDit_GUI.CustomElements
{
    /// <summary>
    /// SSIDBox.xaml etkileşim mantığı
    /// </summary>
    public partial class SSIDBox : UserControl
    {
        public SSID Ssid { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
        public int VisualVote { get; set; }

        public SSIDBox(SSID ssid)
        {
            InitializeComponent();
            this.DataContext = this;
            Ssid = ssid;

            UpVote = Ssid.Votes.Where(x => x.Type == 1).Count();
            DownVote = Ssid.Votes.Where(x => x.Type == 0).Count();
            VisualVote = UpVote - DownVote;

            var vote = ssid.Votes.Where(x => x.Identity == Utils.ID).FirstOrDefault();

            if (vote != null)
                if (vote.Type == 1)
                    UpVoteButton.Background = Brushes.Purple;
                else
                    DownVoteButton.Background = Brushes.Purple;

            Update();
        }

        private void UpVoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UpVoteButton.Background == Brushes.Purple)
            {
                UpVoteButton.Background = Brushes.Transparent;
                UpVote--;
            }
            else
            {
                UpVoteButton.Background = Brushes.Purple;
                UpVote++;

                if (DownVoteButton.Background == Brushes.Purple)
                {
                    DownVoteButton.Background = Brushes.Transparent;
                    DownVote--;
                    Ssid.RevertVote();
                    Update();
                    return;
                }
            }

            Ssid.UpVote();
            Update();
        }

        private void DownVoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DownVoteButton.Background == Brushes.Purple)
            {
                DownVoteButton.Background = Brushes.Transparent;
                DownVote--;
            }
            else
            {
                DownVoteButton.Background = Brushes.Purple;
                DownVote++;

                if (UpVoteButton.Background == Brushes.Purple)
                {
                    UpVoteButton.Background = Brushes.Transparent;
                    UpVote--;
                    Ssid.RevertVote();
                    Update();
                    return;
                }
            }

            Ssid.DownVote();
            Update();
        }

        private void Update()
        {
            VisualVote = UpVote - DownVote;
            VoteCount.Text = $"{VisualVote}";
        }
    }
}
