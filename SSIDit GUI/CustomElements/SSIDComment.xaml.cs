using SSIDit_GUI.Core;
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

namespace SSIDit_GUI.CustomElements
{
    /// <summary>
    /// Interaction logic for SSIDComment.xaml
    /// </summary>
    public partial class SSIDComment : UserControl
    {
        public Comment SsidComment;

        public SSIDComment()
        {
            InitializeComponent();
        }

        public SSIDComment(Comment comment)
        {
            this.SsidComment = comment;
        }

        public string CommentText
        {
            get
            {
                return this.SsidComment.Content;
            }
            set
            {
                if (this.SsidComment.Content != value)
                    SsidComment.Content = value;
            }
        }

        public string Author
        {
            get
            {
                return SsidComment.Author;
            }
        }

        public string Date
        {
            get
            {
                return DateHelper.GetDiffForHumans(this.SsidComment.CreatedAt);
            }
        }
    }
}
