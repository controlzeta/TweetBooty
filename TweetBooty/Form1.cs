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

            //var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            //foreach (var tweet in tweets)
            //{
            //    Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
            //}
        }

        public void Search()
        {   
            SearchOptions search = new SearchOptions ();
            search.Q = txtSearch.Text.Trim();
            search.Count = Convert.ToInt32(cbNumTweets.SelectedText);
            search.IncludeEntities = true;
            search.Resulttype = Utilities.ResultType(cbTypeResult.SelectedIndex);
            service.Search(search);
        }

        public void RateLimit(TwitterRateLimitStatus rate)
        {
            lblRateLimit.Text ="You have used " + rate.RemainingHits + " out of your " + rate.HourlyLimit ;
            lblWaitingTime.Text = "You have to wait: " + rate.ResetTimeInSeconds / 60 + " minutes or to " + rate.ResetTime.ToLongTimeString();
        }

        private void lblRateLimit_Click(object sender, EventArgs e)
        {

        }

        private void lblWaitingTime_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
