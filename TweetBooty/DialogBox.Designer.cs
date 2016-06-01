namespace TweetBooty
{
    partial class DialogBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRT = new System.Windows.Forms.Button();
            this.btnFav = new System.Windows.Forms.Button();
            this.btnRTandFav = new System.Windows.Forms.Button();
            this.lblTweetID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(37, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué quieres hacer con esto?";
            // 
            // btnRT
            // 
            this.btnRT.Location = new System.Drawing.Point(28, 64);
            this.btnRT.Name = "btnRT";
            this.btnRT.Size = new System.Drawing.Size(75, 23);
            this.btnRT.TabIndex = 1;
            this.btnRT.Text = "RT";
            this.btnRT.UseVisualStyleBackColor = true;
            this.btnRT.Click += new System.EventHandler(this.btnRT_Click);
            // 
            // btnFav
            // 
            this.btnFav.Location = new System.Drawing.Point(109, 64);
            this.btnFav.Name = "btnFav";
            this.btnFav.Size = new System.Drawing.Size(75, 23);
            this.btnFav.TabIndex = 2;
            this.btnFav.Text = "FAV";
            this.btnFav.UseVisualStyleBackColor = true;
            this.btnFav.Click += new System.EventHandler(this.btnFav_Click);
            // 
            // btnRTandFav
            // 
            this.btnRTandFav.Location = new System.Drawing.Point(190, 64);
            this.btnRTandFav.Name = "btnRTandFav";
            this.btnRTandFav.Size = new System.Drawing.Size(75, 23);
            this.btnRTandFav.TabIndex = 3;
            this.btnRTandFav.Text = "FAV & RT";
            this.btnRTandFav.UseVisualStyleBackColor = true;
            this.btnRTandFav.Click += new System.EventHandler(this.btnRTandFav_Click);
            // 
            // lblTweetID
            // 
            this.lblTweetID.AutoSize = true;
            this.lblTweetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTweetID.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblTweetID.Location = new System.Drawing.Point(115, 36);
            this.lblTweetID.Name = "lblTweetID";
            this.lblTweetID.Size = new System.Drawing.Size(69, 20);
            this.lblTweetID.TabIndex = 4;
            this.lblTweetID.Text = "TweetID";
            // 
            // DialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 113);
            this.Controls.Add(this.lblTweetID);
            this.Controls.Add(this.btnRTandFav);
            this.Controls.Add(this.btnFav);
            this.Controls.Add(this.btnRT);
            this.Controls.Add(this.label1);
            this.Name = "DialogBox";
            this.Text = "DialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRT;
        private System.Windows.Forms.Button btnFav;
        private System.Windows.Forms.Button btnRTandFav;
        private System.Windows.Forms.Label lblTweetID;
    }
}