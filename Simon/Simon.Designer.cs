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
            this.greenButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.highScore = new System.Windows.Forms.Label();
            this.currentScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.DarkGreen;
            this.greenButton.Location = new System.Drawing.Point(34, 34);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(227, 220);
            this.greenButton.TabIndex = 0;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.greenButton_MouseDown);
            this.greenButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.greenButton_MouseUp);
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.DarkRed;
            this.redButton.Location = new System.Drawing.Point(285, 34);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(227, 220);
            this.redButton.TabIndex = 1;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.redButton_MouseDown);
            this.redButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.redButton_MouseUp);
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Olive;
            this.yellowButton.Location = new System.Drawing.Point(34, 273);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(227, 220);
            this.yellowButton.TabIndex = 2;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yellowButton_MouseDown);
            this.yellowButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.yellowButton_MouseUp);
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Navy;
            this.blueButton.Location = new System.Drawing.Point(285, 273);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(227, 220);
            this.blueButton.TabIndex = 3;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blueButton_MouseDown);
            this.blueButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blueButton_MouseUp);
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(62, 518);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 49);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreLabel.Location = new System.Drawing.Point(318, 503);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.Size = new System.Drawing.Size(115, 26);
            this.HighScoreLabel.TabIndex = 5;
            this.HighScoreLabel.Text = "High Score:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(294, 541);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Score:";
            // 
            // highScore
            // 
            this.highScore.BackColor = System.Drawing.Color.Black;
            this.highScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highScore.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScore.ForeColor = System.Drawing.Color.Lime;
            this.highScore.Location = new System.Drawing.Point(465, 503);
            this.highScore.Name = "highScore";
            this.highScore.Size = new System.Drawing.Size(47, 26);
            this.highScore.TabIndex = 7;
            this.highScore.Text = "00";
            this.highScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentScore
            // 
            this.currentScore.BackColor = System.Drawing.Color.Black;
            this.currentScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentScore.Font = new System.Drawing.Font("Broadway", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentScore.ForeColor = System.Drawing.Color.Lime;
            this.currentScore.Location = new System.Drawing.Point(465, 541);
            this.currentScore.Name = "currentScore";
            this.currentScore.Size = new System.Drawing.Size(47, 26);
            this.currentScore.TabIndex = 8;
            this.currentScore.Text = "00";
            this.currentScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Simon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 594);
            this.Controls.Add(this.currentScore);
            this.Controls.Add(this.highScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HighScoreLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.redButton);
            this.Controls.Add(this.greenButton);
            this.Name = "Simon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simon";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label HighScoreLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label highScore;
        private System.Windows.Forms.Label currentScore;
    }
}

