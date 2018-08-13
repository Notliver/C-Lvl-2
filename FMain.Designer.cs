namespace Kurganskiy_as_game
{
    partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.BtnNewGame = new System.Windows.Forms.Button();
            this.BtnTopPlrs = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnNewGame
            // 
            this.BtnNewGame.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnNewGame.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnNewGame.Location = new System.Drawing.Point(354, 421);
            this.BtnNewGame.Name = "BtnNewGame";
            this.BtnNewGame.Size = new System.Drawing.Size(75, 23);
            this.BtnNewGame.TabIndex = 0;
            this.BtnNewGame.Text = "Новая игра";
            this.BtnNewGame.UseVisualStyleBackColor = false;
            this.BtnNewGame.Click += new System.EventHandler(this.BtnNewGame_Click);
            // 
            // BtnTopPlrs
            // 
            this.BtnTopPlrs.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnTopPlrs.Location = new System.Drawing.Point(354, 450);
            this.BtnTopPlrs.Name = "BtnTopPlrs";
            this.BtnTopPlrs.Size = new System.Drawing.Size(75, 23);
            this.BtnTopPlrs.TabIndex = 1;
            this.BtnTopPlrs.Text = "Рейтинги";
            this.BtnTopPlrs.UseVisualStyleBackColor = false;
            this.BtnTopPlrs.Click += new System.EventHandler(this.BtnTopPlrs_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnExit.Location = new System.Drawing.Point(354, 480);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "Выход";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnTopPlrs);
            this.Controls.Add(this.BtnNewGame);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMain";
            this.Text = "Kurganskiy_AS_game";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNewGame;
        private System.Windows.Forms.Button BtnTopPlrs;
        private System.Windows.Forms.Button BtnExit;
    }
}