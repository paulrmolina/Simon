namespace Simon
{
    partial class Simon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simon));
            this.btnGreenButton = new System.Windows.Forms.Button();
            this.btnRedButton = new System.Windows.Forms.Button();
            this.btnYellowButton = new System.Windows.Forms.Button();
            this.btnBlueButton = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.buttonGroupBox = new System.Windows.Forms.GroupBox();
            this.buttonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGreenButton
            // 
            this.btnGreenButton.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGreenButton.Location = new System.Drawing.Point(13, 13);
            this.btnGreenButton.Name = "btnGreenButton";
            this.btnGreenButton.Size = new System.Drawing.Size(227, 220);
            this.btnGreenButton.TabIndex = 0;
            this.btnGreenButton.UseVisualStyleBackColor = false;
            this.btnGreenButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.greenButton_MouseDown);
            this.btnGreenButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.greenButton_MouseUp);
            // 
            // btnRedButton
            // 
            this.btnRedButton.BackColor = System.Drawing.Color.DarkRed;
            this.btnRedButton.Location = new System.Drawing.Point(264, 13);
            this.btnRedButton.Name = "btnRedButton";
            this.btnRedButton.Size = new System.Drawing.Size(227, 220);
            this.btnRedButton.TabIndex = 1;
            this.btnRedButton.UseVisualStyleBackColor = false;
            this.btnRedButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.redButton_MouseDown);
            this.btnRedButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.redButton_MouseUp);
            // 
            // btnYellowButton
            // 
            this.btnYellowButton.BackColor = System.Drawing.Color.Olive;
            this.btnYellowButton.Location = new System.Drawing.Point(13, 252);
            this.btnYellowButton.Name = "btnYellowButton";
            this.btnYellowButton.Size = new System.Drawing.Size(227, 220);
            this.btnYellowButton.TabIndex = 2;
            this.btnYellowButton.UseVisualStyleBackColor = false;
            this.btnYellowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yellowButton_MouseDown);
            this.btnYellowButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yellowButton_MouseUp);
            // 
            // btnBlueButton
            // 
            this.btnBlueButton.BackColor = System.Drawing.Color.Navy;
            this.btnBlueButton.Location = new System.Drawing.Point(264, 252);
            this.btnBlueButton.Name = "btnBlueButton";
            this.btnBlueButton.Size = new System.Drawing.Size(227, 220);
            this.btnBlueButton.TabIndex = 3;
            this.btnBlueButton.UseVisualStyleBackColor = false;
            this.btnBlueButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blueButton_MouseDown);
            this.btnBlueButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blueButton_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(62, 518);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 49);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.startButton_Click);
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreLabel.Location = new System.Drawing.Point(318, 505);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.Size = new System.Drawing.Size(115, 26);
            this.HighScoreLabel.TabIndex = 5;
            this.HighScoreLabel.Text = "High Score:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Score:";
            // 
            // lblHighScore
            // 
            this.lblHighScore.BackColor = System.Drawing.Color.Black;
            this.lblHighScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHighScore.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.ForeColor = System.Drawing.Color.Lime;
            this.lblHighScore.Location = new System.Drawing.Point(465, 505);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(47, 26);
            this.lblHighScore.TabIndex = 7;
            this.lblHighScore.Text = "00";
            this.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.BackColor = System.Drawing.Color.Black;
            this.lblCurrentScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentScore.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentScore.ForeColor = System.Drawing.Color.Lime;
            this.lblCurrentScore.Location = new System.Drawing.Point(465, 544);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(47, 26);
            this.lblCurrentScore.TabIndex = 8;
            this.lblCurrentScore.Text = "00";
            this.lblCurrentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonGroupBox
            // 
            this.buttonGroupBox.Controls.Add(this.btnBlueButton);
            this.buttonGroupBox.Controls.Add(this.btnYellowButton);
            this.buttonGroupBox.Controls.Add(this.btnRedButton);
            this.buttonGroupBox.Controls.Add(this.btnGreenButton);
            this.buttonGroupBox.Location = new System.Drawing.Point(21, 21);
            this.buttonGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGroupBox.Name = "buttonGroupBox";
            this.buttonGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGroupBox.Size = new System.Drawing.Size(507, 482);
            this.buttonGroupBox.TabIndex = 9;
            this.buttonGroupBox.TabStop = false;
            // 
            // Simon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 594);
            this.Controls.Add(this.buttonGroupBox);
            this.Controls.Add(this.lblCurrentScore);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HighScoreLabel);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Simon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simon";
            this.buttonGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGreenButton;
        private System.Windows.Forms.Button btnRedButton;
        private System.Windows.Forms.Button btnYellowButton;
        private System.Windows.Forms.Button btnBlueButton;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label HighScoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHighScore;
        private System.Windows.Forms.Label lblCurrentScore;
        private System.Windows.Forms.GroupBox buttonGroupBox;
    }
}

