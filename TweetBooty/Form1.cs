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


namespace TweetBooty
{
    public partial class Form1 : Form
    {
        public string _consumerKey = ConfigurationSettings.AppSettings["ConsumerKey"];
        public string _consumerSecret = ConfigurationSettings.AppSettings["ConsumerSecret"];
        public string _accessToken = ConfigurationSettings.AppSettings["AccessToken"];
        public string _accessTokenSecret = ConfigurationSettings.AppSettings["AccessTokenSecret"];

        public TwitterService service; public Utilities utility;
        public static string[] fileEntries;
        public string fullPath;
        public string tweetedPath;

        System.Timers.Timer FifteenMinuteTimer = new System.Timers.Timer();
        System.Timers.Timer OneHourTimer = new System.Timers.Timer();

        public int TweetsByTheHour = 2;
        public int RTsByTheHour = 12;
        public int FavsByTheHour = 12;
        public int FollowsByTheHour = 2;
        public int FifteenMinutes = 0;
        public int Hours = 0;

        public List<TwitterHashTag> hashtags = new List<TwitterHashTag>();
        public List<TwitterHashTag> hashtagsDistintos = new List<TwitterHashTag>();

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            init();
            Connect();
            ScanForMedia();
        }

        public void init()
        {
            cbTypeResult.SelectedIndex = 0;
            for (int i = 1; i <= 10; i++)
            {
                cbNumTweets.Items.Add((i * 10).ToString());
            }
            cbNumTweets.SelectedIndex = 0;

            // Create a 15 minute timer 
            FifteenMinuteTimer = new System.Timers.Timer(15 * 60 * 1000);
            // Hook up the Elapsed event for the timer.
            FifteenMinuteTimer.Elapsed += new ElapsedEventHandler(FifteenMinuteEvent);
            FifteenMinuteTimer.Enabled = true;

            // Create a 1 hour timer 
            FifteenMinuteTimer = new System.Timers.Timer(60 * 60 * 1000);
            // Hook up the Elapsed event for the timer.
            FifteenMinuteTimer.Elapsed += new ElapsedEventHandler(OneHourEvent);
            FifteenMinuteTimer.Enabled = true;

            GetExplorerHashtag();
        }

        public void Connect()
        {
            service = new TwitterService(_consumerKey, _consumerSecret);
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe(new ListTweetsMentioningMeOptions());
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
                                                 where h.repeated > 40
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
            Random rnd = new Random();
            FifteenMinutes++;
            if (TweetsByTheHour > 0)
            { 
                //Tweet
                try
                {
                    TweetsByTheHour++;
                    string nuevoStatus = ConstructTweet(100);
                    SendTweet(nuevoStatus);
                    ShowMessage("Tweet Send!", nuevoStatus);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                TweetsByTheHour--;
            }
            if (RTsByTheHour > 0)
            {
                var statuses = GetBestTweets();
                for (int i = 1; i <= 1; i++)
                { 
                    //Retweet most RT's
                    RTTweet(statuses.ElementAt(i).Id);
                    RTsByTheHour--;
                }
            }
            if (FavsByTheHour > 0)
            {
                var statuses = GetBestTweets();
                for (int i = 1; i <= 2; i++)
                {
                    //Fav most RT's
                    FavTweet(statuses.ElementAt(i).Id);
                    FavsByTheHour--;
                }
            }
            if (FifteenMinutes == 2 || FifteenMinutes == 4 && FollowsByTheHour > 0 )
            { 
                //MostRetweeted follow
                FollowsByTheHour--;
            }
        }

        public List<TwitterStatus> GetBestTweets()
        {
            TwitterSearchResult tweets = Search(getRandomHashtag() + " pic");
            List<TwitterStatus> statuses = (from x in tweets.Statuses
                           orderby x.RetweetCount
                           select x).ToList();
            return statuses;
        }

        private void OneHourEvent(object source, ElapsedEventArgs e)
        {
            Hours++;
            ResetCounters();
        }

        private void ShowMessage(string Caption, string Message)
        {
            string message = Message;
            string caption = Caption;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
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

        public void ShowTweets(TwitterSearchResult tweetsearch)
        {
            dgvTweets.Rows.Clear();
            dgvTweets.Refresh();
            getHashtags(tweetsearch);
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

        public void RateLimit(TwitterRateLimitStatus rate)
        {
            lblRateLimit.Text ="You have used " + rate.RemainingHits + " out of your " + rate.HourlyLimit ;
            lblWaitingTime.Text = "You have to wait: " + rate.ResetTimeInSeconds / 60 + " minutes or to " + rate.ResetTime.ToLongTimeString();
        }

        public void SendTweet(string status)
        {
            if (fileEntries.Length > 0)
            {
                TweetWithMedia(status, fileEntries[0]);
                var list = new List<string>(fileEntries);
                list.Remove(fileEntries[0]);
                fileEntries = list.ToArray();
                lblNumFotos.Text = fileEntries.Length.ToString();
            }
            else
            {
                Tweet(status);
            }
            int tweetCounter = Convert.ToInt32(TweetCounter.Text);
            tweetCounter++;
            TweetCounter.Text = tweetCounter.ToString();
        }

        public void Tweet(string Status)
        {
            try
            {
                SendTweetOptions tweet = new SendTweetOptions();
                tweet.Status = Status;
                service.SendTweet(tweet);
                RateLimit(service.Response.RateLimitStatus);
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
            }
        }

        public void TweetWithMedia(string status, string mediaPath)
        {
            try
            {
                SendTweetWithMediaOptions MediaOp = new SendTweetWithMediaOptions();
                Bitmap img = new Bitmap(mediaPath); //Bitmap img = new Bitmap(@"C:\Users\AngelC\Dropbox\Freelance Ko\TweetBot\logo.jpg");
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Seek(0, SeekOrigin.Begin);
                    Dictionary<string, Stream> images = new Dictionary<string, Stream> { { "mypicture", ms } };
                    var result = service.SendTweetWithMedia(
                        new SendTweetWithMediaOptions { Status = status, Images = images });
                    ((IDisposable)img).Dispose();
                }
                RateLimit(service.Response.RateLimitStatus);
                string copyFilePath = tweetedPath + "\\" + Path.GetFileName(mediaPath);
                System.IO.File.Move(mediaPath, copyFilePath);
            }
            catch (Exception ex)
            {
                lblErrors.Text = "Error: " + ex.Message;
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

        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
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

        #endregion "Funciones"

        #region "Botones"

        private void btnSendTweet_Click(object sender, EventArgs e)
        {
            SendTweet(txtSendTweet.Text);
            ShowMessage("Tweet Send!", txtSendTweet.Text);
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
                catch (Exception ex)
                {
                    lblErrors.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblErrors.Text = "Error: Necesitas escribir un termino de búsqueda";
            }
        }

        #endregion "Botones"
    }
}
