using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TweetSharp;


namespace TweetBooty
{
    public partial class Form1 : Form
    {
        public string _consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
        public string _consumerSecret = ConfigurationSettings.AppSettings["ConsumerSecret"];
        public string _accessToken = ConfigurationSettings.AppSettings["AccessToken"];
        public string _accessTokenSecret = ConfigurationSettings.AppSettings["AccessTokenSecret"];
        public TwitterService service; public Utilities utility;

        public Form1()
        {
            InitializeComponent();
            init();
            Connect();
        }

        public void init()
        {
            cbTypeResult.SelectedIndex = 0;
            for (int i = 1; i <= 10; i++)
            {
                cbNumTweets.Items.Add((i * 10).ToString());
            }
            cbNumTweets.SelectedIndex = 0;
        }

        public void Connect()
        {
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions());
            RateLimit(service.Response.RateLimitStatus);
        }

        public void ShowTweets(TwitterSearchResult tweetsearch)
        {
            dgvTweets.Rows.Clear();
            dgvTweets.Refresh();
            foreach (var tweet in tweetsearch.Statuses)
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvTweets.Rows[0].Clone();
                    row.Cells[0].Value = tweet.Id;                      //TweetId
                    row.Cells[1].Value = tweet.Author.ScreenName;       //Username
                    row.Cells[2].Value = tweet.Text;                    //Tweet
                    row.Cells[3].Value = tweet.RetweetCount;            //RT's
                    dgvTweets.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
        }

        public void RateLimit(TwitterRateLimitStatus rate)
        {
            lblRateLimit.Text ="You have used " + rate.RemainingHits + " out of your " + rate.HourlyLimit ;
            lblWaitingTime.Text = "You have to wait: " + rate.ResetTimeInSeconds / 60 + " minutes or to " + rate.ResetTime.ToLongTimeString();
        }

        public void FavTweet(long tweetID)
        {
            FavoriteTweetOptions fav = new FavoriteTweetOptions();
            fav.Id = tweetID;
            service.FavoriteTweet(fav);
            RateLimit(service.Response.RateLimitStatus);
            int counter = Convert.ToInt32(FavCounter.Text);
            if(service.Response.StatusDescription == "OK")
            {counter++;}
            FavCounter.Text = counter.ToString(); 
        }

        public void RTTweet(long tweetID)
        { 
            RetweetOptions rt = new RetweetOptions();
            rt.Id = tweetID;
            service.Retweet(rt);
            RateLimit(service.Response.RateLimitStatus);
            int counter = Convert.ToInt32(TweetCounter.Text);
            if (service.Response.StatusDescription == "OK")
            { counter++; }
            TweetCounter.Text = counter.ToString(); 
        }

        public void Follow(bool following, string screenName)
        {
            FollowUserOptions follow = new FollowUserOptions();
            follow.Follow = following;
            follow.ScreenName = screenName;
            service.FollowUser(follow);
            RateLimit(service.Response.RateLimitStatus);
            int counter = Convert.ToInt32(FollowCounter.Text);
            if (service.Response.StatusDescription == "OK")
            { counter++; }
            FollowCounter.Text = counter.ToString(); 
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "" && txtSearch.Text.Length > 3)
            {
                try
                {
                    SearchOptions search = new SearchOptions();
                    search.Q = txtSearch.Text.Trim();
                    search.Count = Convert.ToInt32(cbNumTweets.SelectedItem);
                    search.IncludeEntities = true;
                    search.Resulttype = Utilities.ResultType(cbTypeResult.SelectedIndex);
                    ShowTweets(service.Search(search));
                    RateLimit(service.Response.RateLimitStatus);
                }
                catch(Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblErrors.Text = "Error: Necesitas escribir un termino de búsqueda";
            }
        }

        private void dgvTweets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Int32 selectedRowCount = dgvTweets.Rows.GetRowCount(DataGridViewElementStates.Selected);
                string tweetID = ""; string screenName = "";
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        tweetID = dgvTweets.SelectedRows[i].Cells[0].Value.ToString();
                        screenName = dgvTweets.SelectedRows[i].Cells[1].Value.ToString();
                    }
                    DialogBox db = new DialogBox(tweetID, screenName);
                    db.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

      
    }
}
