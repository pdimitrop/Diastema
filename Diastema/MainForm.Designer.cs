namespace Diastema
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            bgTimer = new System.Windows.Forms.Timer(components);
            Player = new PictureBox();
            timerU = new System.Windows.Forms.Timer(components);
            timerD = new System.Windows.Forms.Timer(components);
            timerR = new System.Windows.Forms.Timer(components);
            timerL = new System.Windows.Forms.Timer(components);
            timerMun = new System.Windows.Forms.Timer(components);
            enemyTimer = new System.Windows.Forms.Timer(components);
            timerMunEnemy = new System.Windows.Forms.Timer(components);
            btnRestart = new Button();
            lblGameOver = new Label();
            btnQuit = new Button();
            lblScore = new Label();
            lblLevel = new Label();
            lblCredits = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // bgTimer
            // 
            bgTimer.Enabled = true;
            bgTimer.Interval = 10;
            bgTimer.Tick += bgTimer_Tick;
            // 
            // Player
            // 
            Player.BackColor = Color.Transparent;
            Player.Image = Properties.Resources.laspi;
            Player.Location = new Point(267, 400);
            Player.Name = "Player";
            Player.Size = new Size(50, 50);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.TabIndex = 0;
            Player.TabStop = false;
            // 
            // timerU
            // 
            timerU.Interval = 5;
            timerU.Tick += timerU_Tick;
            // 
            // timerD
            // 
            timerD.Interval = 5;
            timerD.Tick += timerD_Tick;
            // 
            // timerR
            // 
            timerR.Interval = 5;
            timerR.Tick += timerR_Tick;
            // 
            // timerL
            // 
            timerL.Interval = 5;
            timerL.Tick += timerL_Tick;
            // 
            // timerMun
            // 
            timerMun.Enabled = true;
            timerMun.Interval = 20;
            timerMun.Tick += timerMun_Tick;
            // 
            // enemyTimer
            // 
            enemyTimer.Enabled = true;
            enemyTimer.Tick += enemyTimer_Tick;
            // 
            // timerMunEnemy
            // 
            timerMunEnemy.Enabled = true;
            timerMunEnemy.Interval = 20;
            timerMunEnemy.Tick += timerMunEnemy_Tick;
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(168, 195);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(248, 48);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Visible = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font("Maassslicer", 40F);
            lblGameOver.ForeColor = SystemColors.Control;
            lblGameOver.Location = new Point(171, 123);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(242, 62);
            lblGameOver.TabIndex = 3;
            lblGameOver.Text = "ΚΕΙΜΕΝΟ";
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver.Visible = false;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(168, 276);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(248, 48);
            btnQuit.TabIndex = 2;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Visible = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Maassslicer", 14F);
            lblScore.ForeColor = Color.Gold;
            lblScore.Location = new Point(21, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(74, 22);
            lblScore.TabIndex = 4;
            lblScore.Text = "ΣΚΟΡ: ";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Maassslicer", 14F);
            lblLevel.ForeColor = Color.Gold;
            lblLevel.Location = new Point(441, 9);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(100, 22);
            lblLevel.TabIndex = 5;
            lblLevel.Text = "ΕΠΙΠΕΔΟ: ";
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.Font = new Font("Maassslicer", 14F);
            lblCredits.ForeColor = Color.Gold;
            lblCredits.Location = new Point(490, 428);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(82, 22);
            lblCredits.TabIndex = 6;
            lblCredits.Text = "CREDITS";
            lblCredits.Visible = false;
            lblCredits.Click += lblCredits_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 0, 64);
            ClientSize = new Size(584, 461);
            Controls.Add(lblCredits);
            Controls.Add(lblLevel);
            Controls.Add(lblScore);
            Controls.Add(btnQuit);
            Controls.Add(lblGameOver);
            Controls.Add(btnRestart);
            Controls.Add(Player);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Diastema";
            Load += MainForm_Load;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer bgTimer;
        private PictureBox Player;
        private System.Windows.Forms.Timer timerU;
        private System.Windows.Forms.Timer timerD;
        private System.Windows.Forms.Timer timerR;
        private System.Windows.Forms.Timer timerL;
        private System.Windows.Forms.Timer timerMun;
        private System.Windows.Forms.Timer enemyTimer;
        private System.Windows.Forms.Timer timerMunEnemy;
        private Button btnRestart;
        private Label lblGameOver;
        private Button btnQuit;
        private Label lblScore;
        private Label lblLevel;
        private Label lblCredits;
    }
}
