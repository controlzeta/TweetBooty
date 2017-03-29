namespace TweetBooty
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpenImagesFolder = new System.Windows.Forms.Button();
            this.lblDownloadImages = new System.Windows.Forms.Label();
            this.btnGetImages = new System.Windows.Forms.Button();
            this.dgvCurrentHashtags = new System.Windows.Forms.DataGridView();
            this.Hashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbTypeResult = new System.Windows.Forms.ComboBox();
            this.cbNumTweets = new System.Windows.Forms.ComboBox();
            this.dgvTweets = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tweets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnHashtagEdit = new System.Windows.Forms.Button();
            this.btnHashtagDelete = new System.Windows.Forms.Button();
            this.dgvHashtagExplorer = new System.Windows.Forms.DataGridView();
            this.Id_Hashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashtagText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Repeated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblScheduled = new System.Windows.Forms.Label();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.cbTrendingTopics = new System.Windows.Forms.ComboBox();
            this.btnConstructTweet = new System.Windows.Forms.Button();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScreenName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TweetId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvTrendingTopics = new System.Windows.Forms.DataGridView();
            this.TrendingTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendTweet = new System.Windows.Forms.TextBox();
            this.btnSendTweet = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvMentions = new System.Windows.Forms.DataGridView();
            this.MentionUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MentionText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MentionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cbRTLimit = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnNoSaveHashtags = new System.Windows.Forms.RadioButton();
            this.rbtnYesSaveHashtags = new System.Windows.Forms.RadioButton();
            this.cbFollowLimit = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbFavLimit = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTweetLimit = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPhotoLimit = new System.Windows.Forms.ComboBox();
            this.rbtnNoSavePhotos = new System.Windows.Forms.RadioButton();
            this.rbtnYesSavePhotos = new System.Windows.Forms.RadioButton();
            this.cbSpanMinutes = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAccessTokenSecret = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.txtConsumerSecret = new System.Windows.Forms.TextBox();
            this.txtConsumerKey = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ScheduledTab = new System.Windows.Forms.TabPage();
            this.dgvScheduledTweets = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblErrors = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRateLimit = new System.Windows.Forms.Label();
            this.lblWaitingTime = new System.Windows.Forms.Label();
            this.lblNumFotos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FollowCounter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FavCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TweetCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReloadPhotos = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblCounter = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentHashtags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweets)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashtagExplorer)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrendingTopics)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentions)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ScheduledTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledTweets)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Controls.Add(this.tabPage5);
            this.TabControl.Controls.Add(this.ScheduledTab);
            this.TabControl.Location = new System.Drawing.Point(18, 72);
            this.TabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1402, 671);
            this.TabControl.TabIndex = 0;
            this.TabControl.Tag = "Scheduled";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.btnOpenImagesFolder);
            this.tabPage1.Controls.Add(this.lblDownloadImages);
            this.tabPage1.Controls.Add(this.btnGetImages);
            this.tabPage1.Controls.Add(this.dgvCurrentHashtags);
            this.tabPage1.Controls.Add(this.cbTypeResult);
            this.tabPage1.Controls.Add(this.cbNumTweets);
            this.tabPage1.Controls.Add(this.dgvTweets);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1394, 638);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tweet Explorer";
            // 
            // btnOpenImagesFolder
            // 
            this.btnOpenImagesFolder.Location = new System.Drawing.Point(978, 15);
            this.btnOpenImagesFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenImagesFolder.Name = "btnOpenImagesFolder";
            this.btnOpenImagesFolder.Size = new System.Drawing.Size(35, 35);
            this.btnOpenImagesFolder.TabIndex = 14;
            this.btnOpenImagesFolder.Text = "Open Folder";
            this.btnOpenImagesFolder.UseVisualStyleBackColor = true;
            this.btnOpenImagesFolder.Click += new System.EventHandler(this.btnOpenImagesFolder_Click);
            // 
            // lblDownloadImages
            // 
            this.lblDownloadImages.AutoSize = true;
            this.lblDownloadImages.Location = new System.Drawing.Point(1189, 22);
            this.lblDownloadImages.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadImages.Name = "lblDownloadImages";
            this.lblDownloadImages.Size = new System.Drawing.Size(0, 20);
            this.lblDownloadImages.TabIndex = 13;
            // 
            // btnGetImages
            // 
            this.btnGetImages.Location = new System.Drawing.Point(1021, 15);
            this.btnGetImages.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetImages.Name = "btnGetImages";
            this.btnGetImages.Size = new System.Drawing.Size(148, 35);
            this.btnGetImages.TabIndex = 12;
            this.btnGetImages.Text = "Get Images";
            this.btnGetImages.UseVisualStyleBackColor = true;
            this.btnGetImages.Click += new System.EventHandler(this.btnGetImages_Click);
            // 
            // dgvCurrentHashtags
            // 
            this.dgvCurrentHashtags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentHashtags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hashtag});
            this.dgvCurrentHashtags.Location = new System.Drawing.Point(975, 60);
            this.dgvCurrentHashtags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCurrentHashtags.Name = "dgvCurrentHashtags";
            this.dgvCurrentHashtags.Size = new System.Drawing.Size(370, 571);
            this.dgvCurrentHashtags.TabIndex = 11;
            // 
            // Hashtag
            // 
            this.Hashtag.HeaderText = "Hashtag";
            this.Hashtag.Name = "Hashtag";
            this.Hashtag.Width = 200;
            // 
            // cbTypeResult
            // 
            this.cbTypeResult.FormattingEnabled = true;
            this.cbTypeResult.Items.AddRange(new object[] {
            "Mixed",
            "Recent",
            "Popular"});
            this.cbTypeResult.Location = new System.Drawing.Point(675, 17);
            this.cbTypeResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTypeResult.Name = "cbTypeResult";
            this.cbTypeResult.Size = new System.Drawing.Size(124, 28);
            this.cbTypeResult.TabIndex = 9;
            // 
            // cbNumTweets
            // 
            this.cbNumTweets.FormattingEnabled = true;
            this.cbNumTweets.Location = new System.Drawing.Point(590, 17);
            this.cbNumTweets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbNumTweets.Name = "cbNumTweets";
            this.cbNumTweets.Size = new System.Drawing.Size(72, 28);
            this.cbNumTweets.TabIndex = 8;
            // 
            // dgvTweets
            // 
            this.dgvTweets.AllowUserToOrderColumns = true;
            this.dgvTweets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTweets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.UserName,
            this.Tweets,
            this.RTs});
            this.dgvTweets.Location = new System.Drawing.Point(18, 60);
            this.dgvTweets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTweets.Name = "dgvTweets";
            this.dgvTweets.Size = new System.Drawing.Size(906, 571);
            this.dgvTweets.TabIndex = 7;
            this.dgvTweets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTweets_CellContentClick);
            this.dgvTweets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTweets_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Username";
            this.UserName.Name = "UserName";
            // 
            // Tweets
            // 
            this.Tweets.HeaderText = "Tweet";
            this.Tweets.Name = "Tweets";
            this.Tweets.Width = 350;
            // 
            // RTs
            // 
            this.RTs.HeaderText = "RT\'s";
            this.RTs.Name = "RTs";
            this.RTs.Width = 50;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(812, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(84, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(492, 26);
            this.txtSearch.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnHashtagEdit);
            this.tabPage2.Controls.Add(this.btnHashtagDelete);
            this.tabPage2.Controls.Add(this.dgvHashtagExplorer);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1394, 638);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hashtag Explorer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnHashtagEdit
            // 
            this.btnHashtagEdit.Location = new System.Drawing.Point(657, 92);
            this.btnHashtagEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHashtagEdit.Name = "btnHashtagEdit";
            this.btnHashtagEdit.Size = new System.Drawing.Size(144, 35);
            this.btnHashtagEdit.TabIndex = 9;
            this.btnHashtagEdit.Text = "Edit";
            this.btnHashtagEdit.UseVisualStyleBackColor = true;
            this.btnHashtagEdit.Click += new System.EventHandler(this.btnHashtagEdit_Click);
            // 
            // btnHashtagDelete
            // 
            this.btnHashtagDelete.Location = new System.Drawing.Point(657, 43);
            this.btnHashtagDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHashtagDelete.Name = "btnHashtagDelete";
            this.btnHashtagDelete.Size = new System.Drawing.Size(144, 35);
            this.btnHashtagDelete.TabIndex = 7;
            this.btnHashtagDelete.Text = "Delete";
            this.btnHashtagDelete.UseVisualStyleBackColor = true;
            this.btnHashtagDelete.Click += new System.EventHandler(this.btnHashtagDelete_Click);
            // 
            // dgvHashtagExplorer
            // 
            this.dgvHashtagExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHashtagExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Hashtag,
            this.hashtagText,
            this.Date,
            this.Repeated});
            this.dgvHashtagExplorer.Location = new System.Drawing.Point(34, 43);
            this.dgvHashtagExplorer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvHashtagExplorer.Name = "dgvHashtagExplorer";
            this.dgvHashtagExplorer.Size = new System.Drawing.Size(592, 548);
            this.dgvHashtagExplorer.TabIndex = 0;
            // 
            // Id_Hashtag
            // 
            this.Id_Hashtag.HeaderText = "Id\'s";
            this.Id_Hashtag.Name = "Id_Hashtag";
            this.Id_Hashtag.ReadOnly = true;
            this.Id_Hashtag.Width = 50;
            // 
            // hashtagText
            // 
            this.hashtagText.HeaderText = "Hashtag";
            this.hashtagText.Name = "hashtagText";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Repeated
            // 
            this.Repeated.HeaderText = "Repeated";
            this.Repeated.Name = "Repeated";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblScheduled);
            this.tabPage3.Controls.Add(this.btnSchedule);
            this.tabPage3.Controls.Add(this.cbTrendingTopics);
            this.tabPage3.Controls.Add(this.btnConstructTweet);
            this.tabPage3.Controls.Add(this.dgvLog);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.dgvTrendingTopics);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtSendTweet);
            this.tabPage3.Controls.Add(this.btnSendTweet);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1394, 638);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tweet";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblScheduled
            // 
            this.lblScheduled.AutoSize = true;
            this.lblScheduled.Location = new System.Drawing.Point(1113, 32);
            this.lblScheduled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScheduled.Name = "lblScheduled";
            this.lblScheduled.Size = new System.Drawing.Size(0, 20);
            this.lblScheduled.TabIndex = 9;
            // 
            // btnSchedule
            // 
            this.btnSchedule.Location = new System.Drawing.Point(970, 32);
            this.btnSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(111, 35);
            this.btnSchedule.TabIndex = 8;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // cbTrendingTopics
            // 
            this.cbTrendingTopics.FormattingEnabled = true;
            this.cbTrendingTopics.Location = new System.Drawing.Point(974, 94);
            this.cbTrendingTopics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTrendingTopics.Name = "cbTrendingTopics";
            this.cbTrendingTopics.Size = new System.Drawing.Size(368, 28);
            this.cbTrendingTopics.TabIndex = 7;
            this.cbTrendingTopics.SelectedIndexChanged += new System.EventHandler(this.cbTrendingTopics_SelectedIndexChanged);
            // 
            // btnConstructTweet
            // 
            this.btnConstructTweet.Location = new System.Drawing.Point(783, 34);
            this.btnConstructTweet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConstructTweet.Name = "btnConstructTweet";
            this.btnConstructTweet.Size = new System.Drawing.Size(144, 35);
            this.btnConstructTweet.TabIndex = 6;
            this.btnConstructTweet.Text = "Construct Tweet";
            this.btnConstructTweet.UseVisualStyleBackColor = true;
            this.btnConstructTweet.Click += new System.EventHandler(this.btnConstructTweet_Click);
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Text,
            this.ScreenName,
            this.TimeStamp,
            this.TweetId});
            this.dgvLog.Location = new System.Drawing.Point(21, 94);
            this.dgvLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.Size = new System.Drawing.Size(906, 494);
            this.dgvLog.TabIndex = 5;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // Text
            // 
            this.Text.HeaderText = "Text";
            this.Text.Name = "Text";
            // 
            // ScreenName
            // 
            this.ScreenName.HeaderText = "Screen Name";
            this.ScreenName.Name = "ScreenName";
            // 
            // TimeStamp
            // 
            this.TimeStamp.HeaderText = "TimeStamp";
            this.TimeStamp.Name = "TimeStamp";
            // 
            // TweetId
            // 
            this.TweetId.HeaderText = "Id";
            this.TweetId.Name = "TweetId";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1090, 65);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Trending Topics";
            // 
            // dgvTrendingTopics
            // 
            this.dgvTrendingTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrendingTopics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrendingTopic});
            this.dgvTrendingTopics.Location = new System.Drawing.Point(975, 135);
            this.dgvTrendingTopics.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTrendingTopics.Name = "dgvTrendingTopics";
            this.dgvTrendingTopics.Size = new System.Drawing.Size(370, 452);
            this.dgvTrendingTopics.TabIndex = 3;
            // 
            // TrendingTopic
            // 
            this.TrendingTopic.HeaderText = "Trending Topic";
            this.TrendingTopic.Name = "TrendingTopic";
            this.TrendingTopic.Width = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tweets";
            // 
            // txtSendTweet
            // 
            this.txtSendTweet.Location = new System.Drawing.Point(21, 37);
            this.txtSendTweet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSendTweet.Name = "txtSendTweet";
            this.txtSendTweet.Size = new System.Drawing.Size(630, 26);
            this.txtSendTweet.TabIndex = 1;
            // 
            // btnSendTweet
            // 
            this.btnSendTweet.Location = new System.Drawing.Point(662, 34);
            this.btnSendTweet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendTweet.Name = "btnSendTweet";
            this.btnSendTweet.Size = new System.Drawing.Size(112, 35);
            this.btnSendTweet.TabIndex = 0;
            this.btnSendTweet.Text = "Send Tweet";
            this.btnSendTweet.UseVisualStyleBackColor = true;
            this.btnSendTweet.Click += new System.EventHandler(this.btnSendTweet_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvMentions);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(1394, 638);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Mentions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvMentions
            // 
            this.dgvMentions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMentions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MentionUserName,
            this.MentionText,
            this.MentionId});
            this.dgvMentions.Location = new System.Drawing.Point(62, 52);
            this.dgvMentions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMentions.Name = "dgvMentions";
            this.dgvMentions.Size = new System.Drawing.Size(830, 495);
            this.dgvMentions.TabIndex = 0;
            // 
            // MentionUserName
            // 
            this.MentionUserName.HeaderText = "UserName";
            this.MentionUserName.Name = "MentionUserName";
            // 
            // MentionText
            // 
            this.MentionText.HeaderText = "Text";
            this.MentionText.Name = "MentionText";
            this.MentionText.Width = 300;
            // 
            // MentionId
            // 
            this.MentionId.HeaderText = "Id";
            this.MentionId.Name = "MentionId";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.DimGray;
            this.tabPage5.Controls.Add(this.cbRTLimit);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.cbFollowLimit);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.cbFavLimit);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Controls.Add(this.cbTweetLimit);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.cbSpanMinutes);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.txtAccessTokenSecret);
            this.tabPage5.Controls.Add(this.txtAccessToken);
            this.tabPage5.Controls.Add(this.txtConsumerSecret);
            this.tabPage5.Controls.Add(this.txtConsumerKey);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1394, 638);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Configuration";
            // 
            // cbRTLimit
            // 
            this.cbRTLimit.FormattingEnabled = true;
            this.cbRTLimit.Location = new System.Drawing.Point(906, 162);
            this.cbRTLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRTLimit.Name = "cbRTLimit";
            this.cbRTLimit.Size = new System.Drawing.Size(82, 28);
            this.cbRTLimit.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(902, 137);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 20);
            this.label17.TabIndex = 20;
            this.label17.Text = "RT Limit";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnNoSaveHashtags);
            this.groupBox3.Controls.Add(this.rbtnYesSaveHashtags);
            this.groupBox3.Location = new System.Drawing.Point(1026, 129);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(339, 74);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Hashtags on Searches";
            // 
            // rbtnNoSaveHashtags
            // 
            this.rbtnNoSaveHashtags.AutoSize = true;
            this.rbtnNoSaveHashtags.Checked = true;
            this.rbtnNoSaveHashtags.Location = new System.Drawing.Point(171, 31);
            this.rbtnNoSaveHashtags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtnNoSaveHashtags.Name = "rbtnNoSaveHashtags";
            this.rbtnNoSaveHashtags.Size = new System.Drawing.Size(52, 24);
            this.rbtnNoSaveHashtags.TabIndex = 1;
            this.rbtnNoSaveHashtags.TabStop = true;
            this.rbtnNoSaveHashtags.Text = "no";
            this.rbtnNoSaveHashtags.UseVisualStyleBackColor = true;
            // 
            // rbtnYesSaveHashtags
            // 
            this.rbtnYesSaveHashtags.AutoSize = true;
            this.rbtnYesSaveHashtags.Location = new System.Drawing.Point(30, 31);
            this.rbtnYesSaveHashtags.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtnYesSaveHashtags.Name = "rbtnYesSaveHashtags";
            this.rbtnYesSaveHashtags.Size = new System.Drawing.Size(58, 24);
            this.rbtnYesSaveHashtags.TabIndex = 0;
            this.rbtnYesSaveHashtags.Text = "yes";
            this.rbtnYesSaveHashtags.UseVisualStyleBackColor = true;
            // 
            // cbFollowLimit
            // 
            this.cbFollowLimit.FormattingEnabled = true;
            this.cbFollowLimit.Location = new System.Drawing.Point(906, 238);
            this.cbFollowLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFollowLimit.Name = "cbFollowLimit";
            this.cbFollowLimit.Size = new System.Drawing.Size(82, 28);
            this.cbFollowLimit.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(902, 214);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 20);
            this.label16.TabIndex = 17;
            this.label16.Text = "Follow  Limit";
            // 
            // cbFavLimit
            // 
            this.cbFavLimit.FormattingEnabled = true;
            this.cbFavLimit.Location = new System.Drawing.Point(782, 238);
            this.cbFavLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbFavLimit.Name = "cbFavLimit";
            this.cbFavLimit.Size = new System.Drawing.Size(82, 28);
            this.cbFavLimit.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(777, 214);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "Fav Limit";
            // 
            // cbTweetLimit
            // 
            this.cbTweetLimit.FormattingEnabled = true;
            this.cbTweetLimit.Location = new System.Drawing.Point(782, 162);
            this.cbTweetLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbTweetLimit.Name = "cbTweetLimit";
            this.cbTweetLimit.Size = new System.Drawing.Size(82, 28);
            this.cbTweetLimit.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(777, 137);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Tweet Limit";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(620, 455);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbPhotoLimit);
            this.groupBox2.Controls.Add(this.rbtnNoSavePhotos);
            this.groupBox2.Controls.Add(this.rbtnYesSavePhotos);
            this.groupBox2.Location = new System.Drawing.Point(1026, 46);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(339, 74);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Photos on Searches";
            // 
            // cbPhotoLimit
            // 
            this.cbPhotoLimit.FormattingEnabled = true;
            this.cbPhotoLimit.Location = new System.Drawing.Point(246, 29);
            this.cbPhotoLimit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPhotoLimit.Name = "cbPhotoLimit";
            this.cbPhotoLimit.Size = new System.Drawing.Size(82, 28);
            this.cbPhotoLimit.TabIndex = 22;
            // 
            // rbtnNoSavePhotos
            // 
            this.rbtnNoSavePhotos.AutoSize = true;
            this.rbtnNoSavePhotos.Checked = true;
            this.rbtnNoSavePhotos.Location = new System.Drawing.Point(171, 31);
            this.rbtnNoSavePhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtnNoSavePhotos.Name = "rbtnNoSavePhotos";
            this.rbtnNoSavePhotos.Size = new System.Drawing.Size(52, 24);
            this.rbtnNoSavePhotos.TabIndex = 1;
            this.rbtnNoSavePhotos.TabStop = true;
            this.rbtnNoSavePhotos.Text = "no";
            this.rbtnNoSavePhotos.UseVisualStyleBackColor = true;
            // 
            // rbtnYesSavePhotos
            // 
            this.rbtnYesSavePhotos.AutoSize = true;
            this.rbtnYesSavePhotos.Location = new System.Drawing.Point(30, 31);
            this.rbtnYesSavePhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbtnYesSavePhotos.Name = "rbtnYesSavePhotos";
            this.rbtnYesSavePhotos.Size = new System.Drawing.Size(58, 24);
            this.rbtnYesSavePhotos.TabIndex = 0;
            this.rbtnYesSavePhotos.Text = "yes";
            this.rbtnYesSavePhotos.UseVisualStyleBackColor = true;
            // 
            // cbSpanMinutes
            // 
            this.cbSpanMinutes.FormattingEnabled = true;
            this.cbSpanMinutes.Location = new System.Drawing.Point(782, 85);
            this.cbSpanMinutes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSpanMinutes.Name = "cbSpanMinutes";
            this.cbSpanMinutes.Size = new System.Drawing.Size(150, 28);
            this.cbSpanMinutes.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(777, 60);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 20);
            this.label13.TabIndex = 9;
            this.label13.Text = "Span in Minutes";
            // 
            // txtAccessTokenSecret
            // 
            this.txtAccessTokenSecret.Location = new System.Drawing.Point(39, 322);
            this.txtAccessTokenSecret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccessTokenSecret.Name = "txtAccessTokenSecret";
            this.txtAccessTokenSecret.Size = new System.Drawing.Size(616, 26);
            this.txtAccessTokenSecret.TabIndex = 8;
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(39, 238);
            this.txtAccessToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(616, 26);
            this.txtAccessToken.TabIndex = 7;
            // 
            // txtConsumerSecret
            // 
            this.txtConsumerSecret.Location = new System.Drawing.Point(39, 163);
            this.txtConsumerSecret.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConsumerSecret.Name = "txtConsumerSecret";
            this.txtConsumerSecret.Size = new System.Drawing.Size(616, 26);
            this.txtConsumerSecret.TabIndex = 6;
            // 
            // txtConsumerKey
            // 
            this.txtConsumerKey.Location = new System.Drawing.Point(39, 85);
            this.txtConsumerKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConsumerKey.Name = "txtConsumerKey";
            this.txtConsumerKey.Size = new System.Drawing.Size(616, 26);
            this.txtConsumerKey.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(40, 297);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Access Token Secret";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(40, 214);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "AccessToken";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 138);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Consumer Secret";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Consumer Key";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(534, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Configuration Panel";
            // 
            // ScheduledTab
            // 
            this.ScheduledTab.Controls.Add(this.dgvScheduledTweets);
            this.ScheduledTab.Location = new System.Drawing.Point(4, 29);
            this.ScheduledTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScheduledTab.Name = "ScheduledTab";
            this.ScheduledTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ScheduledTab.Size = new System.Drawing.Size(1394, 638);
            this.ScheduledTab.TabIndex = 5;
            this.ScheduledTab.Text = "Scheduled";
            this.ScheduledTab.UseVisualStyleBackColor = true;
            this.ScheduledTab.Click += new System.EventHandler(this.ScheduledTab_Click);
            // 
            // dgvScheduledTweets
            // 
            this.dgvScheduledTweets.AllowUserToOrderColumns = true;
            this.dgvScheduledTweets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScheduledTweets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvScheduledTweets.Location = new System.Drawing.Point(34, 38);
            this.dgvScheduledTweets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvScheduledTweets.Name = "dgvScheduledTweets";
            this.dgvScheduledTweets.Size = new System.Drawing.Size(830, 495);
            this.dgvScheduledTweets.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tweet";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 325;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "TimeToTweet";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(999, 762);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(422, 35);
            this.progressBar.TabIndex = 1;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(27, 771);
            this.lblErrors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(52, 20);
            this.lblErrors.TabIndex = 2;
            this.lblErrors.Text = "Error: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblRateLimit);
            this.flowLayoutPanel1.Controls.Add(this.lblWaitingTime);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(32, 18);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(681, 43);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // lblRateLimit
            // 
            this.lblRateLimit.AutoSize = true;
            this.lblRateLimit.Location = new System.Drawing.Point(4, 0);
            this.lblRateLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRateLimit.Name = "lblRateLimit";
            this.lblRateLimit.Size = new System.Drawing.Size(89, 20);
            this.lblRateLimit.TabIndex = 2;
            this.lblRateLimit.Text = "Rate Limit: ";
            // 
            // lblWaitingTime
            // 
            this.lblWaitingTime.AutoSize = true;
            this.lblWaitingTime.Location = new System.Drawing.Point(101, 0);
            this.lblWaitingTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWaitingTime.Name = "lblWaitingTime";
            this.lblWaitingTime.Size = new System.Drawing.Size(141, 20);
            this.lblWaitingTime.TabIndex = 3;
            this.lblWaitingTime.Text = "You Have to wait : ";
            // 
            // lblNumFotos
            // 
            this.lblNumFotos.AutoSize = true;
            this.lblNumFotos.Location = new System.Drawing.Point(936, 20);
            this.lblNumFotos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumFotos.Name = "lblNumFotos";
            this.lblNumFotos.Size = new System.Drawing.Size(18, 20);
            this.lblNumFotos.TabIndex = 14;
            this.lblNumFotos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(880, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Photos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FollowCounter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FavCounter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TweetCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(1000, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(410, 75);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counters";
            // 
            // FollowCounter
            // 
            this.FollowCounter.AutoSize = true;
            this.FollowCounter.Location = new System.Drawing.Point(369, 31);
            this.FollowCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FollowCounter.Name = "FollowCounter";
            this.FollowCounter.Size = new System.Drawing.Size(18, 20);
            this.FollowCounter.TabIndex = 5;
            this.FollowCounter.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(303, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Follows:";
            // 
            // FavCounter
            // 
            this.FavCounter.AutoSize = true;
            this.FavCounter.Location = new System.Drawing.Point(243, 31);
            this.FavCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FavCounter.Name = "FavCounter";
            this.FavCounter.Size = new System.Drawing.Size(18, 20);
            this.FavCounter.TabIndex = 3;
            this.FavCounter.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Favs:";
            // 
            // TweetCounter
            // 
            this.TweetCounter.AutoSize = true;
            this.TweetCounter.Location = new System.Drawing.Point(148, 31);
            this.TweetCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TweetCounter.Name = "TweetCounter";
            this.TweetCounter.Size = new System.Drawing.Size(18, 20);
            this.TweetCounter.TabIndex = 1;
            this.TweetCounter.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "RT\'s o Tweets:";
            // 
            // btnReloadPhotos
            // 
            this.btnReloadPhotos.Location = new System.Drawing.Point(852, 46);
            this.btnReloadPhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReloadPhotos.Name = "btnReloadPhotos";
            this.btnReloadPhotos.Size = new System.Drawing.Size(144, 35);
            this.btnReloadPhotos.TabIndex = 16;
            this.btnReloadPhotos.Text = "Reload Photos";
            this.btnReloadPhotos.UseVisualStyleBackColor = true;
            this.btnReloadPhotos.Click += new System.EventHandler(this.btnReloadPhotos_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(753, 49);
            this.lblCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(71, 20);
            this.lblCounter.TabIndex = 4;
            this.lblCounter.Text = "00:00:00";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(741, 18);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Next Action";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1438, 815);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnReloadPhotos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblNumFotos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentHashtags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweets)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashtagExplorer)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrendingTopics)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentions)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ScheduledTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScheduledTweets)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTweets;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox cbTypeResult;
        private System.Windows.Forms.ComboBox cbNumTweets;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tweets;
        private System.Windows.Forms.DataGridViewTextBoxColumn RTs;
        private System.Windows.Forms.DataGridView dgvCurrentHashtags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hashtag;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSendTweet;
        private System.Windows.Forms.Button btnSendTweet;
        private System.Windows.Forms.DataGridView dgvHashtagExplorer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Hashtag;
        private System.Windows.Forms.DataGridViewTextBoxColumn hashtagText;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Repeated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvTrendingTopics;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScreenName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TweetId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrendingTopic;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvMentions;
        private System.Windows.Forms.DataGridViewTextBoxColumn MentionUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MentionText;
        private System.Windows.Forms.DataGridViewTextBoxColumn MentionId;
        private System.Windows.Forms.Button btnConstructTweet;
        private System.Windows.Forms.Button btnHashtagEdit;
        private System.Windows.Forms.Button btnHashtagDelete;
        private System.Windows.Forms.ComboBox cbTrendingTopics;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblRateLimit;
        private System.Windows.Forms.Label lblWaitingTime;
        private System.Windows.Forms.Label lblNumFotos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label FollowCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label FavCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TweetCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.TextBox txtConsumerSecret;
        private System.Windows.Forms.TextBox txtConsumerKey;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAccessTokenSecret;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnNoSavePhotos;
        private System.Windows.Forms.RadioButton rbtnYesSavePhotos;
        private System.Windows.Forms.ComboBox cbSpanMinutes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbFollowLimit;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbFavLimit;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbTweetLimit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnNoSaveHashtags;
        private System.Windows.Forms.RadioButton rbtnYesSaveHashtags;
        private System.Windows.Forms.ComboBox cbRTLimit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnReloadPhotos;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnGetImages;
        private System.Windows.Forms.ComboBox cbPhotoLimit;
        private System.Windows.Forms.Label lblScheduled;
        private System.Windows.Forms.Label lblDownloadImages;
        private System.Windows.Forms.TabPage ScheduledTab;
        private System.Windows.Forms.DataGridView dgvScheduledTweets;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnOpenImagesFolder;

    }
}

