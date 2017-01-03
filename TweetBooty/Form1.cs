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
using System.IO;
using System.Reflection;
using System.Timers;
using System.Xml;
using System.Net;
using HtmlAgilityPack;
using System.Threading;
using System.Text.RegularExpressions;
using System.Data.Objects;
using System.Threading;


namespace TweetBooty
{
    public partial class Form1 : Form
    {
        public string _consumerKey = "";
        public string _consumerSecret = "";
        public string _accessToken = "";
        public string _accessTokenSecret = "";

        public TwitterService service; public Utilities utility;
        public static string[] fileEntries;
        public static List<TweetBooty.Archive.FolderName> folderNames;
        public string fullPath;
        public string tweetedPath;

        System.Timers.Timer FifteenMinuteTimer = new System.Timers.Timer();
        System.Timers.Timer OneHourTimer = new System.Timers.Timer();

        public int TweetsByTheHour = 0;
        public int RTsByTheHour = 0;
        public int FavsByTheHour = 0;
        public int FollowsByTheHour = 0;
        public int FifteenMinutes = 0;
        public int Hours = 0;
        public int minutesLeft = 0;
        public int secondsLeft = 0;
        public int DownloadCounter = 0;
        Random rand = new Random();

        public List<TwitterHashTag> hashtags = new List<TwitterHashTag>();
        public List<TwitterHashTag> hashtagsDistintos = new List<TwitterHashTag>();
        public List<TwitterUser> friendList = new List<TwitterUser>();
        public Imaging img = new Imaging();

        private Thread trd;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Connect();
            init();
            getNumberOfPhotos();
            folderNames = img.GetFolderNames();
            //GetFollowList();
            //Recommended();
        }

        public void init()
        {
            cbTypeResult.SelectedIndex = 0;
            for (int i = 1; i <= 10; i++)
            {
                cbNumTweets.Items.Add((i * 10).ToString());
            }
            for (int i = 2; i <= 6; i++)
            {
                cbNumTweets.Items.Add((i * 100).ToString());
            }
            cbNumTweets.SelectedIndex = 0;

            for (int i = 1; i <= 12; i++)
            {
                cbSpanMinutes.Items.Add((i * 5).ToString());
            }
            cbSpanMinutes.SelectedIndex = 2;

            for (int i = 1; i <= 15; i++)
            {
                cbTweetLimit.Items.Add((i).ToString());
            }
            cbTweetLimit.SelectedIndex = 2;

            for (int i = 1; i <= 15; i++)
            {
                cbRTLimit.Items.Add((i).ToString());
            }
            cbRTLimit.SelectedIndex = 2;

            for (int i = 1; i <= 15; i++)
            {
                cbFavLimit.Items.Add((i).ToString());
            }
            cbFavLimit.SelectedIndex = 2;

            for (int i = 1; i <= 10; i++)
            {
                cbFollowLimit.Items.Add((i).ToString());
            }
            cbFollowLimit.SelectedIndex = 0;

            for (int i = 1; i <= 10; i++)
            {
                cbPhotoLimit.Items.Add((i*10).ToString());
            }
            for (int i = 2; i <= 6; i++)
            {
                cbPhotoLimit.Items.Add((i * 100).ToString());
            }
            cbPhotoLimit.SelectedIndex = 4;
            // Create a 15 minute timer 
            //FifteenMinuteTimer = new System.Timers.Timer(15 * 60 * 1000);
            //// Hook up the Elapsed event for the timer.
            //FifteenMinuteTimer.Elapsed += new ElapsedEventHandler(FifteenMinuteEvent);
            //FifteenMinuteTimer.Enabled = true;
            RandomTime();

            // Create a 1 hour timer 
            FifteenMinuteTimer = new System.Timers.Timer(60 * 60 * 1000);
            // Hook up the Elapsed event for the timer.
            FifteenMinuteTimer.Elapsed += new ElapsedEventHandler(OneHourEvent);
            FifteenMinuteTimer.Enabled = true;

            GetExplorerHashtag();
            GetTrendingTopics( 0 );
            getLog();
            GetMentions();
            GetCountries();
            GetScheduledTweets();
        }

        public void Connect()
        {
            GetConfiguration();
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
        }

        public void GetConfiguration()
        {
            using (TweetBotDBEntities bd = new TweetBotDBEntities())
            {
                var config = (from cfg in bd.Configurations
                              select cfg).FirstOrDefault();

                _consumerKey = config.ConsumerKey;
                _consumerSecret = config.ConsumerSecret;
                _accessToken = config.AccessToken;
                _accessTokenSecret = config.AccessTokenSecret;
                TweetsByTheHour = config.TweetLimit;
                RTsByTheHour = config.TweetLimit;
                FavsByTheHour = config.FavLimit;
                FollowsByTheHour = config.FollowLimit;

                txtConsumerKey.Text = _consumerKey;
                txtConsumerSecret.Text = _consumerSecret;
                txtAccessToken.Text = _accessToken;
                txtAccessTokenSecret.Text = _accessTokenSecret;
            }
        }

        private void getNumberOfPhotos()
        {
            fileEntries = img.ScanForMedia();
            lblNumFotos.Text = fileEntries.Length.ToString();
        }

        public void GetMentions()
        {
            dgvMentions.Rows.Clear();
            dgvMentions.Refresh();
            List<TwitterStatus> mentions = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions()).ToList();
            foreach (TwitterStatus t in mentions)
            {
                DataGridViewRow row = (DataGridViewRow)dgvMentions.Rows[0].Clone();
                row.Cells[0].Value = t.Author.ScreenName;                   //UserName
                row.Cells[1].Value = t.Text;                                //Text
                row.Cells[2].Value = t.Id.ToString();                         //Id
                dgvMentions.Rows.Add(row);
            }
            RateLimit(service.Response.RateLimitStatus);
        }

        public void GetExplorerHashtag()
        {
            dgvHashtagExplorer.Rows.Clear();
            dgvHashtagExplorer.Refresh();
            using (TweetBotDBEntities bd = new TweetBotDBEntities())
            {
                var lsthashtags = (from h in bd.Hashtags
                                   where h.repeated > 50
                                   select h).ToList();
                foreach (Hashtag hash in lsthashtags)
                {
                    try
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvTweets.Rows[0].Clone();
                        row.Cells[0].Value = hash.id;                               //HashtagId
                        row.Cells[1].Value = hash.hashtag1.Trim();                  //Hashtag
                        row.Cells[2].Value = hash.timestamp.ToShortDateString();    //Date
                        row.Cells[3].Value = hash.repeated;                         //Repeated
                        dgvHashtagExplorer.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        lblErrors.Text = "Error: " + ex.Message;
                    }
                }

            }
        }

        public void GetScheduledTweets()
        {
            dgvScheduledTweets.Rows.Clear();
            dgvScheduledTweets.Refresh();
            using (TweetBotDBEntities bd = new TweetBotDBEntities())
            {
                DateTime thisMoment = new DateTime();
                thisMoment = DateTime.Now;
                var lstProgrammedTweets = (from pt in bd.ProgrammedTweets
                                   where pt.Tweeted == false 
                                   && EntityFunctions.TruncateTime(pt.Time) >= EntityFunctions.TruncateTime(thisMoment)
                                   select pt).ToList();
                foreach (var ptweet in lstProgrammedTweets)
                {
                    try
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvScheduledTweets.Rows[0].Clone();
                        row.Cells[0].Value = ptweet.Id;                                 //ProgrammedTweetId
                        row.Cells[1].Value = ptweet.Tweet;                              //TweetText
                        row.Cells[2].Value = ptweet.Time.ToShortTimeString();           //TimeToTweet
                        dgvScheduledTweets.Rows.Add(row);
                    }
                    catch (Exception ex)
                    {
                        lblErrors.Text = "Error: " + ex.Message;
                    }
                }

            }
        }

        public string ConstructTweet(int tweetLength)
        {
            string nuevoStatus = "";
            try
            {
                Random rnd = new Random();
                using (TweetBotDBEntities bd = new TweetBotDBEntities())
                {
                    int NumLinks = (from li in bd.Links
                                    select li).ToList().Count;
                    int random = rnd.Next(1, NumLinks);
                    Link link = (from l in bd.Links
                                 where l.id == random
                                 select l).FirstOrDefault();
                    nuevoStatus = ShortenedString(link.title, tweetLength);
                    int counter = 0;
                    while (nuevoStatus.Length <= tweetLength)
                    {
                        List<Hashtag> lsthashtags = (from h in bd.Hashtags
                                                     where h.repeated > 80
                                                     select h).ToList();
                        random = rnd.Next(0, lsthashtags.Count);
                        if ((nuevoStatus.Length + lsthashtags.ElementAt(random).hashtag1.Trim().Length + 2) < tweetLength)
                        {
                            nuevoStatus = nuevoStatus + " #" + lsthashtags.ElementAt(random).hashtag1.Trim();
                        }
                        else
                        {
                            counter++;
                        }
                        if (counter == 5)
                        {
                            break;
                        }
                    }
                    nuevoStatus = ShortenedString(nuevoStatus, tweetLength) + " " + link.link1;
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
            return nuevoStatus;
        }

        private void FifteenMinuteEvent(object source, ElapsedEventArgs e)
        {
            try
                {
                timer1.Stop();
                FifteenMinuteTimer.Stop();
                trd = new Thread(new ThreadStart(this.RandomTasks));
                trd.IsBackground = true;
                trd.Start();
                getLog();
                RandomTime();

                }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        private void RandomTasks()
        {
            int times = rand.Next(1, 5);
            bool AlreadyRecommended = false;
            while (times > 0)
            {
                int action = rand.Next(1, 6);
                switch (action)
                {
                    case 1: //Tweet
                        string nuevoStatus = ConstructTweet(85);
                        SendTweet(nuevoStatus);
                        break;
                    case 2: //Fav
                        var statuses = GetBestTweets();
                        if (statuses.Count > 0)
                        {
                            FavTweet(statuses.ElementAt(0).Id, statuses.ElementAt(0).Text);
                        }
                        break;
                    case 3: //RT
                        var statuses2 = GetBestTweets();
                        if (statuses2.Count > 0)
                        {
                            RTTweet(statuses2.ElementAt(0).Id, statuses2.ElementAt(0).Text);
                        }
                        break;
                    case 4: //RT & FAV
                        var statuses3 = GetBestTweets();
                        if (statuses3.Count > 0)
                        {
                            FavTweet(statuses3.ElementAt(0).Id, statuses3.ElementAt(0).Text);
                            RTTweet(statuses3.ElementAt(0).Id, statuses3.ElementAt(0).Text);
                        }
                        break;
                    case 5: //Recommend
                        if (!AlreadyRecommended)
                        {
                            Recommended();
                            AlreadyRecommended = true;
                        }
                        break;
                    case 6: //Get new images
                        SearchNewImagesbyFolder();
                        break;
                }
                times--;
            }
        }

        private void RandomTime()
        {
            minutesLeft = rand.Next(30, 52);
            //rand.Next(Convert.ToInt32(cbNumTweets.SelectedItem),
            //        Convert.ToInt32(cbNumTweets.SelectedItem) + 20);
            // Create a random minute timer 
            //FifteenMinuteTimer = new System.Timers.Timer( minutesLeft * 60 * 1000);
            timer1.Enabled = true;
            // Hook up the Elapsed event for the timer.
            //FifteenMinuteTimer.Elapsed += new ElapsedEventHandler(FifteenMinuteEvent);
            //FifteenMinuteTimer.Enabled = true;
            secondsLeft = minutesLeft * 60;
            timer1.Start();
        }

        private void OneHourEvent(object source, ElapsedEventArgs e)
        {
            Hours++;
            ResetCounters();
            GetTrendingTopics(0);
            GetMentions();
            getNumberOfPhotos();
        }

        public List<TwitterStatus> GetBestTweets()
        {
            List<TwitterStatus> statuses = new List<TwitterStatus>();
            TwitterSearchResult tweets = Search(getRandomHashtag() + " pic");
            if (tweets != null)
            {
                statuses = (from x in tweets.Statuses
                                                orderby x.RetweetCount
                                                select x).ToList();
            }
            return statuses;
        }

        public void GetTrendingTopics(int id)
        {
            ListLocalTrendsForOptions lctfo = new ListLocalTrendsForOptions();
            lctfo.Id = id == 0 ? 116545 : id; //Mexico City
            //lctfo.Id = 116545; //Mexico City
            //lctfo.Id = 134047; //Monterrey
            //lctfo.Id = 395269; //Caracas
            //lctfo.Id = 753692; //Barcelona
            //lctfo.Id = 766273; //Madrid
            var trendss = service.ListLocalTrendsFor(lctfo);
            dgvTrendingTopics.Rows.Clear();
            dgvTrendingTopics.Refresh();
            foreach(TwitterTrend tt in trendss)
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvTrendingTopics.Rows[0].Clone();
                    row.Cells[0].Value = tt.Name;                                   //TrendingTopic
                    //row.Cells[1].Value = tt.TrendingAsOf.ToShortTimeString();       //StartedTrendingAt
                    dgvTrendingTopics.Rows.Add(row);
                }
                catch (Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
        }

        public void GetCountries()
        {
            var countries = service.ListAvailableTrendsLocations();
            cbTrendingTopics.DisplayMember = "Text";
            cbTrendingTopics.ValueMember = "Value";
            foreach(WhereOnEarthLocation country in countries )
            {
                ComboboxItem cbi = new ComboboxItem();
                cbi.Text = country.Country + " - " + country.Name;
                cbi.Value = country.WoeId;
                cbTrendingTopics.Items.Add(cbi);
                //cbTrendingTopics.Items.Add(new { 
                //    Text = country.Country + " - " + country.Name , 
                //    Value = country.WoeId });
                
            }
        }

        private void ShowMessage(string Caption, string Message)
        {
            string message = Message;
            string caption = Caption;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
        }

        public void ResetCounters()
        {
            TweetsByTheHour = 2;
            RTsByTheHour = 13;
            FavsByTheHour = 15;
            FollowsByTheHour = 2;
            FifteenMinutes = 0;
        }

        public void ShowTweets(TwitterSearchResult tweetsearch, string terminoBusqueda)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            progressBar.Step = 1;
            dgvTweets.Rows.Clear();
            dgvTweets.Refresh();
            getHashtags(tweetsearch);
            progressBar.Maximum = tweetsearch.Statuses.ToList().Count;
            foreach (var tweet in tweetsearch.Statuses)
            {
                try
                {
                    DataGridViewRow row = (DataGridViewRow)dgvTweets.Rows[0].Clone();
                    row.Cells[0].Value = tweet.Id;                      //TweetId
                    row.Cells[1].Value = tweet.Author.ScreenName;       //Username
                    row.Cells[2].Value = tweet.Text;                    //Tweet
                    row.Cells[3].Value = tweet.RetweetCount;            //RT's
                    if (rbtnYesSavePhotos.Checked)
                    {
                        //if (!tweet.Text.Contains("RT @"))
                        //{
                            getTweetImage(constructStatusURL(tweet.Author.ScreenName, tweet.IdStr), terminoBusqueda, tweet.IdStr);
                        //}
                        //else
                        //{
                        //    Console.WriteLine(tweet.RawSource);
                        //}
                    }
                    dgvTweets.Rows.Add(row);
                    progressBar.PerformStep();
                }
                catch (Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
        }

        public string constructStatusURL(string user, string id)
        {
            return "https://twitter.com/" + user + "/status/" + id;
        }

        public void getHashtags(TwitterSearchResult tweetsearch)
        {
            try
            {

                hashtagsDistintos = new List<TwitterHashTag>();
                foreach (var tweet in tweetsearch.Statuses)
                {
                    hashtags = hashtags.Concat(tweet.Entities.HashTags).ToList();
                }
                hashtagsDistintos = hashtags.Distinct(new HashtagComparer()).ToList();
                dgvCurrentHashtags.Rows.Clear();
                dgvCurrentHashtags.Refresh();
                foreach (TwitterHashTag hash in hashtagsDistintos)
                {
                    DataGridViewRow row = (DataGridViewRow)dgvCurrentHashtags.Rows[0].Clone();
                    row.Cells[0].Value = hash.Text;
                    dgvCurrentHashtags.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void getLog()
        {
            try
            {
                dgvLog.Rows.Clear();
                dgvLog.Refresh();
                using (TweetBotDBEntities bd = new TweetBotDBEntities())
                {
                    var oldTweets = (from o in bd.Tweeteds
                                     orderby o.Id descending
                                     select o).Take(50).ToList();
                    foreach (Tweeted t in oldTweets)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvLog.Rows[0].Clone();
                        row.Cells[0].Value = t.Action;                          //Action
                        row.Cells[1].Value = t.Text;                            //Text
                        row.Cells[2].Value = t.Username;                        //ScreenName
                        row.Cells[3].Value = t.Timestamp.ToString();            //TimeStamp
                        row.Cells[4].Value = t.TweetId;                         //Id
                        dgvLog.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void RateLimit(TwitterRateLimitStatus rate)
        {
            lblRateLimit.Text ="You have used " + rate.RemainingHits + " out of your " + rate.HourlyLimit ;
            lblWaitingTime.Text = "You have to wait: " + rate.ResetTimeInSeconds / 60 + " minutes or to " + rate.ResetTime.ToLongTimeString();
        }

        public bool SendTweet(string status)
        {
            progressBar.Visible = true;
            progressBar.Minimum = 1;
            progressBar.Value = 1;
            progressBar.Step = 1;
            progressBar.Maximum = 3;
            bool success = false;
            if (fileEntries != null && fileEntries.Length > 0)
            {
                success = TweetWithMedia(status, fileEntries[0]);
                var list = new List<string>(fileEntries);
                list.Remove(fileEntries[0]);
                fileEntries = list.ToArray();
                lblNumFotos.Text = fileEntries.Length.ToString();
                progressBar.PerformStep();
            }
            else
            {
                success = Tweet(status);
            }
            if (success)
            {
                int tweetCounter = Convert.ToInt32(TweetCounter.Text);
                tweetCounter++;
                TweetCounter.Text = tweetCounter.ToString();
                progressBar.PerformStep();
            }
            getLog();
            progressBar.PerformStep();
            progressBar.Visible = false;
            return success;
        }

        public bool Tweet(string Status)
        {
            try
            {
                SendTweetOptions tweet = new SendTweetOptions();
                tweet.Status = Status;
                var result = service.SendTweet(tweet);
                RateLimit(service.Response.RateLimitStatus);
                if (result != null)
                {
                    SaveAction("Tweet", Status, result.Id, result.User.ScreenName);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
                return false;
            }
        }

        public bool TweetWithMedia(string status, string mediaPath)
        {
            try
            {
                TwitterStatus result;
                SendTweetWithMediaOptions MediaOp = new SendTweetWithMediaOptions();
                Bitmap img = new Bitmap(mediaPath); //Bitmap img = new Bitmap(@"C:\Users\AngelC\Dropbox\Freelance Ko\TweetBot\logo.jpg");
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Seek(0, SeekOrigin.Begin);
                    Dictionary<string, Stream> images = new Dictionary<string, Stream> { { "mypicture", ms } };
                    result = service.SendTweetWithMedia(
                        new SendTweetWithMediaOptions { Status = status, Images = images });
                    ((IDisposable)img).Dispose();
                }
                RateLimit(service.Response.RateLimitStatus);
                if (result != null)
                {
                    SaveAction("Tweet", status, result.Id, result.User.ScreenName);
                    string copyFilePath = tweetedPath + "\\" + Path.GetFileName(mediaPath);
                    System.IO.File.Move(mediaPath, copyFilePath);
                    return true;
                }
                lblErrors.Text = service.Response.StatusDescription + " " + service.Response.Error;
                return false;
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
                return false;
            }
        }

        private string ShortenedString(string linea, int medida)
        {
            if (linea.Length <= medida)
            {
                return linea;
            }
            string lineaCorta;
            int cuantos = linea.Length - medida;
            lineaCorta = linea.Remove(medida, cuantos);
            return lineaCorta;
        }

        public void FavTweet(long tweetID, string tweet)
        {
            FavoriteTweetOptions fav = new FavoriteTweetOptions();
            fav.Id = tweetID;
            service.FavoriteTweet(fav);
            RateLimit(service.Response.RateLimitStatus);
            int counter = Convert.ToInt32(FavCounter.Text);
            if(service.Response.StatusDescription == "OK")
            {
                SaveAction("Favorite", tweet, tweetID, " ");
                counter++;
            }
            FavCounter.Text = counter.ToString();
            getLog();
        }

        public void RTTweet(long tweetID, string tweet)
        { 
            RetweetOptions rt = new RetweetOptions();
            rt.Id = tweetID;
            service.Retweet(rt);
            RateLimit(service.Response.RateLimitStatus);
            int counter = Convert.ToInt32(TweetCounter.Text);
            if (service.Response.StatusDescription == "OK")
            {
                SaveAction("ReTweet", tweet, tweetID, " ");
                counter++; 
            }
            TweetCounter.Text = counter.ToString();
            getLog();
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
            {
                SaveAction( following ? "Follow" : "Unfollow", " ", 0, screenName);
                counter++; 
            }
            FollowCounter.Text = counter.ToString();
            getLog();
        }

        public void SendDirectMessage(string message, string screenName, long userId)
        {
            try
            {
                TwitterDirectMessage DM = new TwitterDirectMessage();
                SendDirectMessageOptions options = new SendDirectMessageOptions();
                options.Text = message;
                options.ScreenName = screenName;
                options.UserId = userId;
                DM = service.SendDirectMessage(options);
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void GetFollowList()
        { 
            TwitterCursorList<TwitterUser> lstUsers;
            ListFriendsOptions lstOptions = new ListFriendsOptions();
            lstOptions.ScreenName = "nalgaprontacom";
            lstOptions.IncludeUserEntities = true;
            lstOptions.UserId = 2290097750;
            lstOptions.Count = 500;
            lstUsers = service.ListFriends(lstOptions);
            FollowListOptions followList = new FollowListOptions();
            followList.OwnerId = 2290097750;
            followList.OwnerScreenName = "nalgaprontacom";

            ListFollowersOptions lstFollowers = new ListFollowersOptions();
            lstFollowers.ScreenName = "nalgaprontacom";
            lstFollowers.IncludeUserEntities = true;
            lstFollowers.UserId = 2290097750;
            TwitterCursorList<TwitterUser> lstFollows = service.ListFollowers(lstFollowers);

            foreach (TwitterUser t in lstFollows)
            {
                SendDirectMessage("Gracias por seguirnos, visita nalgapronta.com papi.", t.ScreenName, t.Id);
            }
        }

        public string MustFollow()
        {
            string[] mustFollow = { 
                                      "#mustFollow: ", 
                                      "#RT y #Follow plis! ",
                                      "Tienes que seguirlos: ", 
                                      "Necesitas seguir estas cuentas: ", 
                                      "Siguelos y te sigo ", 
                                      "#NeedToFollow: ", 
                                      "Los mejores tweet son de: ", 
                                      "Siguelos: ", 
                                  };
            int randomNumber = rand.Next(0, mustFollow.Length);
            return mustFollow[randomNumber];
        }

        public void Recommended()
        {
            /// To do:
            /// Get a bio from user
            /// use info to relate user and find hashtags
            /// Recommend with random texts
            ListFriendsOptions Friends = new ListFriendsOptions
            {
                IncludeUserEntities = true,
                ScreenName = "nalgaprontamx",
                Count = 200
            };
            friendList = service.ListFriends(Friends);
            string status = MustFollow();
            int contador = 0;
            while (status.Length <= 88 && contador <= 6)
            {
                int index = rand.Next(0, friendList.Count);
                if (friendList.ElementAt(index).ScreenName.Length + status.Length <= 87)
                {
                    status += " @" + friendList.ElementAt(index).ScreenName + " ";
                }
                contador++;
                friendList.RemoveAt(index);
            }
            SendTweet(status);
        }

        private TwitterSearchResult Search(string query)
        {
            SearchOptions search = new SearchOptions();
            TwitterSearchResult results = new TwitterSearchResult();
            search.Q = query;
            search.Count = 50;
            search.IncludeEntities = true;
            search.Resulttype = TwitterSearchResultType.Mixed;
            results = service.Search(search);
            RateLimit(service.Response.RateLimitStatus);
            return results;
        }

        public void SearchNewImagesbyFolder()
        {
            try
            {
                folderNames = img.GetFolderNames();
                int count = 0;
                bool SavePhotosState = false;
                SavePhotosState = rbtnYesSavePhotos.Checked;
                rbtnYesSavePhotos.Checked = true;
                foreach (TweetBooty.Archive.FolderName folder in folderNames)
                {
                    if (count <= 5)
                    {
                        txtSearch.Text = folder.folderName;
                        txtSearch.Update();
                        SearchOptions search = new SearchOptions();
                        search.Q = folder.folderName;
                        search.Count = Convert.ToInt32(cbPhotoLimit.SelectedItem);
                        search.IncludeEntities = true;
                        search.Resulttype = TwitterSearchResultType.Recent;
                        Directory.SetLastWriteTime(folder.path, DateTime.Now);
                        ShowTweets(service.Search(search), folder.folderName);
                        RateLimit(service.Response.RateLimitStatus);
                        count++;
                        txtSearch.Text = "";
                    }
                }
                rbtnYesSavePhotos.Checked = SavePhotosState;
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void getTweetImage(string urlAddress, string hashtag, string tweetId)
        {
            try
            {
                string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string exeDir = Path.GetDirectoryName(exeFile);
                string extension = "";
                fullPath = Path.Combine(exeDir + "\\Images\\" + hashtag);
                if (!System.IO.Directory.Exists(fullPath))
                {
                    System.IO.Directory.CreateDirectory(fullPath);
                }
                HtmlWeb client = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = client.Load(urlAddress);
                HtmlNodeCollection Nodes = doc.DocumentNode.SelectNodes("//img[@src]");
                HtmlNodeCollection VideoNodes = doc.DocumentNode.SelectNodes("//*[contains(@class,'PlayableMedia-player')]");
                //doc.DocumentNode.SelectNodes("//*[contains(@class,'float')]");
                if (VideoNodes != null)
                {
                    foreach (var link in VideoNodes)
                    {
                        string oldStyle = link.Attributes["style"].Value;
                        var images = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Contains("style") && d.Attributes["style"].Value.Contains("background-image:url")).FirstOrDefault();

                        if (oldStyle.Contains("https://pbs.twimg.com/tweet_video_thumb/"))
                        {
                            string foundIt = Path.GetFileNameWithoutExtension(Regex.Match(oldStyle, @"\(([^)]*)\)").Groups[1].Value);
                            string ext = Path.GetExtension(Regex.Match(oldStyle, @"\(([^)]*)\)").Groups[1].Value);
                            if (ext == ".jpg'")
                            {
                                if (!File.Exists(fullPath + "\\" + foundIt + ".mp4"))
                                {
                                    using (WebClient webClient = new WebClient())
                                    {
                                        string URL = "https://pbs.twimg.com/tweet_video/"; //CxvQiYrXEAEHCml.mp4
                                        URL += foundIt + ".mp4";
                                        webClient.DownloadFile(new Uri(URL), fullPath + "\\" + foundIt + ".mp4");
                                        DownloadCounter++;
                                    }
                                }
                            }
                        }
                    }
                }
                if (Nodes != null)
                {
                    foreach (var link in Nodes)
                    {
                        if (link.OuterHtml.Contains("media"))
                        {
                            var imgURL = link.Attributes["src"].Value.ToString().Substring(0, link.Attributes["src"].Value.Length -6);
                            using (WebClient webClient = new WebClient())
                            {
                                var imgName = Path.GetFileNameWithoutExtension(imgURL);
                                extension = Path.GetExtension(imgURL);
                                if (extension == ".jpg")
                                {
                                    if (!File.Exists(fullPath + "\\" + imgName + extension))
                                    {
                                        //webClient.DownloadFile(new Uri(link.Attributes["src"].Value), fullPath + "\\" + hashtag + "-" + DateTime.Now.ToUniversalTime().ToString("MMMM-dd-yyyy-H-mm-ss") + extension);
                                        webClient.DownloadFile(new Uri(imgURL), fullPath + "\\" + imgName + extension);
                                        DownloadCounter++;
                                        lblDownloadImages.Text = "Downloading : " + DownloadCounter +" pics.";
                                        lblDownloadImages.Update();
                                    }
                                }
                            }
                        }
                        if (link.OuterHtml.Contains("video-display"))
                        {
                            Console.WriteLine(link.Attributes["src"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            lblErrors.Text = "Error: " + ex.Message;
            }
        }

        private void dgvTweets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Int32 selectedRowCount = dgvTweets.Rows.GetRowCount(DataGridViewElementStates.Selected);
                string tweetID = ""; string screenName = ""; string tweet = "";
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        tweetID = dgvTweets.SelectedRows[i].Cells[0].Value.ToString();
                        screenName = dgvTweets.SelectedRows[i].Cells[1].Value.ToString();
                        tweet = dgvTweets.SelectedRows[i].Cells[2].Value.ToString();
                    }
                    DialogBox db = new DialogBox(tweetID, screenName, tweet);
                    db.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        #region "Database Access"

        private void readSiteMap()
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                // Poner un Examinar para elegir el archivo de sitemap
                xdoc.Load(@"C:\Users\Francisco\Dropbox\Freelance Ko\TweetBot\TweetBot\App_Data\sitemap.xml");
                XmlNodeList nodelist = xdoc.SelectNodes("//item");
                using (TweetBotDBEntities bd = new TweetBotDBEntities())
                {
                    Link link = new Link();
                    foreach (XmlNode node in nodelist)
                    {
                        link = new Link();
                        link.title = node["title"].InnerText;
                        link.description = node["description"].InnerText;
                        link.link1 = node["link"].InnerText;
                        link.sortOrder = Convert.ToInt32(node["ror:sortOrder"].InnerText);
                        if (link.sortOrder != 1)
                        {
                            bd.Links.Add(link);
                            bd.SaveChanges();
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                throw ex;
            }
        }

        public void SaveHashtags()
        {
            try
            {
                using (TweetBotDBEntities bd = new TweetBotDBEntities())
                {
                    List<BannedWord> lstBanned = (from banned in bd.BannedWords
                                                  select banned).ToList();

                    Hashtag h = new TweetBooty.Hashtag();
                    int contains = 0;
                    foreach (TwitterHashTag hash in hashtagsDistintos)
                    {
                        List<Hashtag> query = (from b in bd.Hashtags
                                               orderby b.id
                                               where b.hashtag1 == hash.Text
                                               select b).ToList();
                        //query.Where(m => m.hashtag.ToLower() == hash.Text.ToLower()).ToList();
                        h = new TweetBooty.Hashtag();
                        if (query.Count < 1)
                        {
                            h.hashtag1 = hash.Text.ToLower();
                            h.timestamp = DateTime.Now;
                            h.repeated = 1; contains = 0;
                            foreach (BannedWord ban in lstBanned)
                            {
                                if (h.hashtag1.Contains(ban.bannedWord1))
                                {
                                    contains++;
                                }
                            }
                            if (contains == 0)
                                bd.Hashtags.Add(h);
                        }
                        else
                        {
                            h = query.FirstOrDefault();
                            h.repeated++;
                            bd.Entry(h).State = EntityState.Modified;
                        }
                        bd.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }

        }

        public string getRandomHashtag()
        {
            Random rnd = new Random(); int random = 0;
            List<Hashtag> lsthashtags;
            using (TweetBotDBEntities bd = new TweetBotDBEntities())
            {
                lsthashtags = (from h in bd.Hashtags
                               where h.repeated > 40
                               select h).ToList();
                random = rnd.Next(0, lsthashtags.Count);
            }
            return lsthashtags.ElementAt(random).hashtag1;
        }

        public void SaveAction(string action, string text, long TweetId, string Username)
        {
            try
            {
                using (TweetBotDBEntities bd = new TweetBotDBEntities())
                {
                    Tweeted t = new Tweeted();
                    t.Action = action;
                    t.Text = text;
                    t.Timestamp = DateTime.Now;
                    t.TweetId = TweetId;
                    t.Username = Username;
                    bd.Tweeteds.Add(t);
                    bd.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        #endregion "Database Access"

        #region "Funciones"

        class HashtagComparer : IEqualityComparer<TwitterHashTag>
        {
            public bool Equals(TwitterHashTag x, TwitterHashTag y)
            {
                if (Object.ReferenceEquals(x, y)) return true;

                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                return x.Text.ToLower() == y.Text.ToLower() && x.EntityType == y.EntityType;
            }

            public int GetHashCode(TwitterHashTag Hashtag)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(Hashtag, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = Hashtag.Text == null ? 0 : Hashtag.Text.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = Hashtag.EntityType.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        #endregion "Funciones"

        #region "Botones"

        private void btnSendTweet_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            if(SendTweet(txtSendTweet.Text))
                ShowMessage("Tweet Send!", txtSendTweet.Text);
            else
                ShowMessage("Something went wrong!", txtSendTweet.Text);
            btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            if (txtSearch.Text != "" && txtSearch.Text.Length > 3)
            {
                try
                {
                    SearchOptions search = new SearchOptions();
                    search.Q = txtSearch.Text.Trim();
                    search.Count = Convert.ToInt32(cbNumTweets.SelectedItem);
                    search.IncludeEntities = true;
                    search.Resulttype = Utilities.ResultType(cbTypeResult.SelectedIndex);
                    ShowTweets(service.Search(search), txtSearch.Text.Trim());
                    RateLimit(service.Response.RateLimitStatus);
                    if (rbtnYesSaveHashtags.Checked)
                    {
                        SaveHashtags();
                    }
                }
                catch (Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblErrors.Text = "Error: Necesitas escribir un termino de búsqueda";
            }
            btnSearch.Enabled = true;
        }

        private void btnConstructTweet_Click(object sender, EventArgs e)
        {
            var nuevoStatus = ConstructTweet(85);
            Clipboard.SetText(nuevoStatus);
            txtSendTweet.Text = nuevoStatus;
        }

        private void btnReloadPhotos_Click(object sender, EventArgs e)
        {
            getNumberOfPhotos();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            //Programar un tweet con una hora especifica o automática 
            try
            {
                if (txtSendTweet.Text == "" || txtSendTweet.Text.Length <= 8)
                {
                    lblScheduled.Text = "";
                    lblErrors.Text = "You Need to write something to schedule a tweet.";
                }
                else
                {
                    using (TweetBotDBEntities bd = new TweetBotDBEntities())
                    {
                        DateTime thisMoment = new DateTime();
                        thisMoment = DateTime.Now;

                        var TweetsProgramados = (from prog in bd.ProgrammedTweets
                                                 where EntityFunctions.TruncateTime(prog.Time) >= EntityFunctions.TruncateTime(thisMoment)
                                                 && prog.Tweeted != true
                                                 select prog).Take(25).ToList();

                        TweetsProgramados.Sort((y, x) => y.Time.CompareTo(x.Time));

                        ProgrammedTweet pt = new ProgrammedTweet();
                        pt.Tweet = txtSendTweet.Text;
                        if (TweetsProgramados.Last().Time.Date < DateTime.Now.Date)
                        {
                            pt.Time = DateTime.Now.AddMinutes(rand.Next(60, 90));
                        }
                        else
                        {
                            pt.Time = TweetsProgramados.Last().Time.AddMinutes(rand.Next(65, 100));
                        }
                        pt.Tweeted = false;
                        pt.Link = getLink(txtSendTweet.Text);
                        bd.ProgrammedTweets.Add(pt);
                        bd.SaveChanges();
                        lblScheduled.Text = "Your tweet has been programmed!";
                        GetScheduledTweets();
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
                lblScheduled.Text = "We are not able to program your tweet!";
                lblScheduled.Text = "";
            }
        }

        private void btnGetImages_Click(object sender, EventArgs e)
        {
            SearchNewImagesbyFolder();
        }

        private void btnHashtagDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnHashtagEdit_Click(object sender, EventArgs e)
        {

        }

        private void cbTrendingTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            GetTrendingTopics(Convert.ToInt32(((TweetBooty.Form1.ComboboxItem)(comboBox.SelectedItem)).Value));
        }

        #endregion "Botones"

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (secondsLeft != 0)
                {
                    if (secondsLeft % 60 == 0)
                    { CheckProgrammedTweets(); }
                    lblCounter.Text = ((secondsLeft / 60).ToString().Count<char>() == 1 ?
                        "0" + (secondsLeft / 60).ToString() :
                        (secondsLeft / 60).ToString()) + ":" +
                        ((secondsLeft % 60).ToString().Count<char>() == 1 ?
                        "0" + (secondsLeft % 60).ToString() :
                        (secondsLeft % 60).ToString());
                    secondsLeft--;
                }
                else
                {
                    FifteenMinuteEvent(this, null);
                }
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void CheckProgrammedTweets()
        {
            using (TweetBotDBEntities bd = new TweetBotDBEntities())
            {
                DateTime thisMoment = new DateTime();
                thisMoment = DateTime.Now;
                var ProgTweets = (from pt in bd.ProgrammedTweets
                                  where EntityFunctions.TruncateTime(pt.Time) >= EntityFunctions.TruncateTime(thisMoment)
                                  && pt.Tweeted == false
                              select pt 
                              ).ToList();
                if (ProgTweets.Count > 0)
                {
                    foreach (ProgrammedTweet pT in ProgTweets)
                    {
                        if (pT.Time.ToString("HH:mm") == thisMoment.ToString("HH:mm"))
                        {
                            SendTweet(pT.Tweet);
                            pT.Tweeted = true;
                            bd.ProgrammedTweets.Attach(pT);
                            bd.Entry(pT).State = EntityState.Modified;
                            bd.SaveChanges();
                        }
                    }
                }
            }
        }

        public string getLink(string Status)
        {
            Regex regx = new Regex("http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?", RegexOptions.IgnoreCase);
            MatchCollection matches = regx.Matches(Status);
            foreach (Match m in matches)
            {
                return m.Value;
            }
            return "";
        }

        private void ScheduledTab_Click(object sender, EventArgs e)
        {
            GetScheduledTweets();
        }

    }
}
