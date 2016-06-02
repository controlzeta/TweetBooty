using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TweetBooty
{
    public partial class DialogBox : Form
    {
        public DialogBox()
        {
            InitializeComponent();
        }

        public DialogBox(string TweetID, string ScreenName)
        {
            InitializeComponent();
            lblTweetID.Text = TweetID;
            lblScreenName.Text = ScreenName;
        }

        private void btnRT_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).RTTweet(Convert.ToInt64(lblTweetID.Text));
            }
            this.Hide();
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).FavTweet(Convert.ToInt64(lblTweetID.Text));
            }
            this.Hide();
        }

        private void btnRTandFav_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).FavTweet(Convert.ToInt64(lblTweetID.Text));
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).RTTweet(Convert.ToInt64(lblTweetID.Text));
            }
            this.Hide();
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).Follow(true, lblScreenName.Text);
            }
            this.Hide();
        }
    }
}
