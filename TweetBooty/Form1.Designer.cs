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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNumFotos = new System.Windows.Forms.Label();
            this.dgvCurrentHashtags = new System.Windows.Forms.DataGridView();
            this.Hashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FollowCounter = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FavCounter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TweetCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTypeResult = new System.Windows.Forms.ComboBox();
            this.cbNumTweets = new System.Windows.Forms.ComboBox();
            this.dgvTweets = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tweets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRateLimit = new System.Windows.Forms.Label();
            this.lblWaitingTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvHashtagExplorer = new System.Windows.Forms.DataGridView();
            this.Id_Hashtag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hashtagText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Repeated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendTweet = new System.Windows.Forms.TextBox();
            this.btnSendTweet = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblErrors = new System.Windows.Forms.Label();
            this.dgvTrendingTopics = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.TrendingTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentHashtags)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweets)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashtagExplorer)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrendingTopics)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 451);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNumFotos);
            this.tabPage1.Controls.Add(this.dgvCurrentHashtags);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbTypeResult);
            this.tabPage1.Controls.Add(this.cbNumTweets);
            this.tabPage1.Controls.Add(this.dgvTweets);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtSearch);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(927, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tweet Explorer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNumFotos
            // 
            this.lblNumFotos.AutoSize = true;
            this.lblNumFotos.Location = new System.Drawing.Point(594, 22);
            this.lblNumFotos.Name = "lblNumFotos";
            this.lblNumFotos.Size = new System.Drawing.Size(13, 13);
            this.lblNumFotos.TabIndex = 12;
            this.lblNumFotos.Text = "0";
            // 
            // dgvCurrentHashtags
            // 
            this.dgvCurrentHashtags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentHashtags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hashtag});
            this.dgvCurrentHashtags.Location = new System.Drawing.Point(650, 80);
            this.dgvCurrentHashtags.Name = "dgvCurrentHashtags";
            this.dgvCurrentHashtags.Size = new System.Drawing.Size(247, 330);
            this.dgvCurrentHashtags.TabIndex = 11;
            // 
            // Hashtag
            // 
            this.Hashtag.HeaderText = "Hashtag";
            this.Hashtag.Name = "Hashtag";
            this.Hashtag.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FollowCounter);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FavCounter);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TweetCounter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(636, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contadores";
            // 
            // FollowCounter
            // 
            this.FollowCounter.AutoSize = true;
            this.FollowCounter.Location = new System.Drawing.Point(246, 20);
            this.FollowCounter.Name = "FollowCounter";
            this.FollowCounter.Size = new System.Drawing.Size(13, 13);
            this.FollowCounter.TabIndex = 5;
            this.FollowCounter.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Follows:";
            // 
            // FavCounter
            // 
            this.FavCounter.AutoSize = true;
            this.FavCounter.Location = new System.Drawing.Point(162, 20);
            this.FavCounter.Name = "FavCounter";
            this.FavCounter.Size = new System.Drawing.Size(13, 13);
            this.FavCounter.TabIndex = 3;
            this.FavCounter.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Favs:";
            // 
            // TweetCounter
            // 
            this.TweetCounter.AutoSize = true;
            this.TweetCounter.Location = new System.Drawing.Point(99, 20);
            this.TweetCounter.Name = "TweetCounter";
            this.TweetCounter.Size = new System.Drawing.Size(13, 13);
            this.TweetCounter.TabIndex = 1;
            this.TweetCounter.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "RT\'s o Tweets:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(557, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fotos:";
            // 
            // cbTypeResult
            // 
            this.cbTypeResult.FormattingEnabled = true;
            this.cbTypeResult.Items.AddRange(new object[] {
            "Mixed",
            "Recent",
            "Popular"});
            this.cbTypeResult.Location = new System.Drawing.Point(450, 47);
            this.cbTypeResult.Name = "cbTypeResult";
            this.cbTypeResult.Size = new System.Drawing.Size(84, 21);
            this.cbTypeResult.TabIndex = 9;
            // 
            // cbNumTweets
            // 
            this.cbNumTweets.FormattingEnabled = true;
            this.cbNumTweets.Location = new System.Drawing.Point(393, 47);
            this.cbNumTweets.Name = "cbNumTweets";
            this.cbNumTweets.Size = new System.Drawing.Size(49, 21);
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
            this.dgvTweets.Location = new System.Drawing.Point(12, 75);
            this.dgvTweets.Name = "dgvTweets";
            this.dgvTweets.Size = new System.Drawing.Size(604, 335);
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
            this.btnSearch.Location = new System.Drawing.Point(541, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(56, 49);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblRateLimit);
            this.flowLayoutPanel1.Controls.Add(this.lblWaitingTime);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(541, 28);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // lblRateLimit
            // 
            this.lblRateLimit.AutoSize = true;
            this.lblRateLimit.Location = new System.Drawing.Point(3, 0);
            this.lblRateLimit.Name = "lblRateLimit";
            this.lblRateLimit.Size = new System.Drawing.Size(60, 13);
            this.lblRateLimit.TabIndex = 2;
            this.lblRateLimit.Text = "Rate Limit: ";
            // 
            // lblWaitingTime
            // 
            this.lblWaitingTime.AutoSize = true;
            this.lblWaitingTime.Location = new System.Drawing.Point(69, 0);
            this.lblWaitingTime.Name = "lblWaitingTime";
            this.lblWaitingTime.Size = new System.Drawing.Size(98, 13);
            this.lblWaitingTime.TabIndex = 3;
            this.lblWaitingTime.Text = "You Have to wait : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvHashtagExplorer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(927, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hashtag Explorer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHashtagExplorer
            // 
            this.dgvHashtagExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHashtagExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Hashtag,
            this.hashtagText,
            this.Date,
            this.Repeated});
            this.dgvHashtagExplorer.Location = new System.Drawing.Point(23, 28);
            this.dgvHashtagExplorer.Name = "dgvHashtagExplorer";
            this.dgvHashtagExplorer.Size = new System.Drawing.Size(395, 356);
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
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.dgvTrendingTopics);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.txtSendTweet);
            this.tabPage3.Controls.Add(this.btnSendTweet);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(927, 425);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tweet";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Tweets";
            // 
            // txtSendTweet
            // 
            this.txtSendTweet.Location = new System.Drawing.Point(14, 24);
            this.txtSendTweet.Name = "txtSendTweet";
            this.txtSendTweet.Size = new System.Drawing.Size(421, 20);
            this.txtSendTweet.TabIndex = 1;
            // 
            // btnSendTweet
            // 
            this.btnSendTweet.Location = new System.Drawing.Point(441, 22);
            this.btnSendTweet.Name = "btnSendTweet";
            this.btnSendTweet.Size = new System.Drawing.Size(75, 23);
            this.btnSendTweet.TabIndex = 0;
            this.btnSendTweet.Text = "Send Tweet";
            this.btnSendTweet.UseVisualStyleBackColor = true;
            this.btnSendTweet.Click += new System.EventHandler(this.btnSendTweet_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(666, 465);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(281, 23);
            this.progressBar.TabIndex = 1;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(13, 466);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(35, 13);
            this.lblErrors.TabIndex = 2;
            this.lblErrors.Text = "Error: ";
            // 
            // dgvTrendingTopics
            // 
            this.dgvTrendingTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrendingTopics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrendingTopic,
            this.TrendDate});
            this.dgvTrendingTopics.Location = new System.Drawing.Point(552, 45);
            this.dgvTrendingTopics.Name = "dgvTrendingTopics";
            this.dgvTrendingTopics.Size = new System.Drawing.Size(339, 348);
            this.dgvTrendingTopics.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(678, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Trending Topics";
            // 
            // TrendingTopic
            // 
            this.TrendingTopic.HeaderText = "Trending Topic";
            this.TrendingTopic.Name = "TrendingTopic";
            this.TrendingTopic.Width = 200;
            // 
            // TrendDate
            // 
            this.TrendDate.HeaderText = "Date";
            this.TrendDate.Name = "TrendDate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 487);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tweet Booty - Yummy Tweets";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentHashtags)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTweets)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashtagExplorer)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrendingTopics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblWaitingTime;
        private System.Windows.Forms.Label lblRateLimit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTweets;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox cbTypeResult;
        private System.Windows.Forms.ComboBox cbNumTweets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label FollowCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label FavCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TweetCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tweets;
        private System.Windows.Forms.DataGridViewTextBoxColumn RTs;
        private System.Windows.Forms.DataGridView dgvCurrentHashtags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hashtag;
        private System.Windows.Forms.Label lblNumFotos;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn TrendingTopic;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrendDate;

    }
}

