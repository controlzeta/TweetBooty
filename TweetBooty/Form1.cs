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
        Random rand = new Random();

        public List<TwitterHashTag> hashtags = new List<TwitterHashTag>();
        public List<TwitterHashTag> hashtagsDistintos = new List<TwitterHashTag>();

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Connect();
            init();
            ScanForMedia();
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
        }

        public void Connect()
        {
            GetConfiguration();
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
        }

        public void GetConfiguration()
        {
            using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
            using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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

        public string ConstructTweet(int tweetLength)
        {
            Random rnd = new Random();
            string nuevoStatus = ""; 
            using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
            return nuevoStatus;
        }

        private void FifteenMinuteEvent(object source, ElapsedEventArgs e)
        {
            try
                {
                timer1.Stop();
                FifteenMinuteTimer.Stop();
                // Create Random number 
                int times = rand.Next(1,5);
                while (times > 0)
                {
                    int action = rand.Next(1, 3);
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
                    }
                    times--;
                }
                //progressBar.Visible = true;
                //progressBar.Minimum = 1;
                //progressBar.Value = 1;
                //progressBar.Step = 1;
                //progressBar.Maximum = 4;
                //Random rnd = new Random();
                //FifteenMinutes++;
                //progressBar.PerformStep();
                //if (TweetsByTheHour > 0)
                //{
                //    //Tweet
                //    TweetsByTheHour++;
                //    string nuevoStatus = ConstructTweet(85);
                //    SendTweet(nuevoStatus);
                //    //if (SendTweet(nuevoStatus))
                //    //ShowMessage("Tweet Send!", nuevoStatus);
                //}
                //if (RTsByTheHour > 0)
                //{
                //    var statuses = GetBestTweets();
                //    if (statuses.Count > 0) 
                //    {
                //        for (int i = 1; i <= 1; i++)
                //        {
                //            //Retweet most RT's
                //            RTTweet(statuses.ElementAt(i).Id, statuses.ElementAt(i).Text);
                //            RTsByTheHour--;
                //        }
                //    }
                //}
                //progressBar.PerformStep();
                //if (FavsByTheHour > 0)
                //{
                //    var statuses = GetBestTweets();
                //    if (statuses.Count > 0)
                //    {
                //        for (int i = 1; i <= 2; i++)
                //        {
                //            //Fav most RT's
                //            if(statuses.Count >= i)
                //                FavTweet(statuses.ElementAt(i).Id, statuses.ElementAt(i).Text);
                //            FavsByTheHour--;
                //        }
                //    }
                //}
                //progressBar.PerformStep();
                //if (FifteenMinutes == 2 || FifteenMinutes == 4 && FollowsByTheHour > 0 )
                //{ 
                //    //MostRetweeted follow
                //    FollowsByTheHour--;
                //}
                getLog();
                RandomTime();

                }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        private void RandomTime()
        {
            minutesLeft =
            rand.Next(Convert.ToInt32(cbNumTweets.SelectedItem),
                    Convert.ToInt32(cbNumTweets.SelectedItem) + 20);
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
            ScanForMedia();
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
                using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
                return false;
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
                return false;
            }
        }

        public void ScanForMedia()
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            //string fullPath = Path.Combine(exeDir, "..\\..\\Images\\");
            fullPath = Path.Combine(exeDir + "\\Images\\");
            tweetedPath = Path.Combine(exeDir + "\\Images\\tweeted");
            if (Directory.Exists(fullPath))
            {
                lblNumFotos.Text = ProcessDirectory(fullPath).ToString();
            }
            if (!System.IO.Directory.Exists(tweetedPath))
            {
                System.IO.Directory.CreateDirectory(tweetedPath);
            }
        
        }

        public static int ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            fileEntries = Directory.GetFiles(targetDirectory);
            return fileEntries.Length;
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
                foreach (var link in Nodes)
                {
                    if (link.OuterHtml.Contains("aria"))
                    {
                        Console.WriteLine(link.Attributes["src"].Value);
                        using (WebClient webClient = new WebClient())
                        {
                            var imgName = Path.GetFileNameWithoutExtension(link.Attributes["src"].Value);
                            extension = Path.GetExtension(link.Attributes["src"].Value);
                            if(extension == ".jpg")
                            {
                                if (!File.Exists(fullPath + "\\" + imgName + extension))
                                {
                                    //webClient.DownloadFile(new Uri(link.Attributes["src"].Value), fullPath + "\\" + hashtag + "-" + DateTime.Now.ToUniversalTime().ToString("MMMM-dd-yyyy-H-mm-ss") + extension);
                                    webClient.DownloadFile(new Uri(link.Attributes["src"].Value), fullPath + "\\" + imgName + extension);
                                }
                            }
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
                using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
                using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
            using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
                using (TweetBootyDBEntities bd = new TweetBootyDBEntities())
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
            txtSendTweet.Text = ConstructTweet(85);
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

        private void btnReloadPhotos_Click(object sender, EventArgs e)
        {
            ScanForMedia();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (secondsLeft != 0)
            {
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

    }
}
