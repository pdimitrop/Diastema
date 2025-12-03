using System.Drawing.Text;
using WMPLib;

namespace Diastema
{
    internal partial class MainForm : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] enemiesMun;
        private int enemiesMunSpeed;

        PictureBox[] stars;
        private int bgSpeed;
        private int plSpeed;

        PictureBox[] munitions;
        private int munSpeed;

        PictureBox[] enemies;
        private int enemySpeed;

        Random rand;

        private int score;
        private int level;
        private int difficulty;
        private bool pause;
        private bool gameOver;

        PrivateFontCollection fonts;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        internal MainForm()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pause = false;
            gameOver = false;
            score = 0;
            level = 1;
            difficulty = 9;

            fonts = new PrivateFontCollection();
            string fontPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "font", "maassslicer.italic.ttf"));
            fonts.AddFontFile(fontPath);

            lblScore.Font = new Font(fonts.Families[0], 14F);
            lblLevel.Font = new Font(fonts.Families[0], 14F);
            lblCredits.Font = new Font(fonts.Families[0], 14F);
            lblGameOver.Font = new Font(fonts.Families[0], 40F);

            bgSpeed = 4;
            plSpeed = 4;
            enemySpeed = 4;
            munSpeed = 20;
            enemiesMunSpeed = 4;

            munitions = new PictureBox[3];

            Image munition = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "mud.png")));

            Image enemyDK = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "AT.png")));
            Image enemyNA = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "NA.png")));
            Image enemyAT = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "DK.png")));
            Image bossZK = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "ZK.png")));
            Image bossKM = Image.FromFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "assets", "KM.png")));

            enemies = new PictureBox[10];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = bossKM;
            enemies[1].Image = enemyNA;
            enemies[2].Image = enemyAT;
            enemies[3].Image = enemyAT;
            enemies[4].Image = enemyDK;
            enemies[5].Image = enemyAT;
            enemies[6].Image = enemyNA;
            enemies[7].Image = enemyAT;
            enemies[8].Image = enemyNA;
            enemies[9].Image = bossZK;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(30, 30);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            gameMedia = new WindowsMediaPlayer();
            shootMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            gameMedia.URL = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "bgm", "sample.wav"));
            shootMedia.URL = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "bgm", "shoot.wav"));
            explosion.URL = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src", "bgm", "explosion.wav"));

            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 100;
            shootMedia.settings.volume = 10;
            explosion.settings.volume = 6;

            stars = new PictureBox[15];
            rand = new Random();
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rand.Next(20, 580), rand.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }

            enemiesMun = new PictureBox[10];
            for (int i = 0; i < enemiesMun.Length; i++)
            {
                enemiesMun[i] = new PictureBox();
                enemiesMun[i].Size = new Size(2, 25);
                enemiesMun[i].Visible = false;
                enemiesMun[i].BackColor = Color.Yellow;
                int x = rand.Next(0, 10);
                enemiesMun[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMun[i]);
            }

            gameMedia.controls.play();

            lblScore.Text = "ΣΚΟΡ: 0" + score;
            lblLevel.Text = "ΕΠΙΠΕΔΟ: 0" + level;
        }

        #region Timers
        private void bgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += bgSpeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += bgSpeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void timerU_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10) Player.Top -= plSpeed;
        }

        private void timerD_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 400) Player.Top += plSpeed;
        }

        private void timerR_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580) Player.Left += plSpeed;
        }

        private void timerL_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10) Player.Left -= plSpeed;
        }

        private void timerMun_Tick(object sender, EventArgs e)
        {
            shootMedia.controls.play();
            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= munSpeed;

                    Collision();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        private void timerMunEnemy_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (munitions.Length - difficulty); i++)
            {
                if (enemiesMun[i].Top < this.Height)
                {
                    enemiesMun[i].Visible = true;
                    enemiesMun[i].Top += enemiesMunSpeed;

                    CollisionWithMun();
                }
                else
                {
                    enemiesMun[i].Visible = false;
                    int x = rand.Next(0, 10);
                    enemiesMun[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemySpeed);
        }
        #endregion

        #region Events
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                    case Keys.W:
                        timerU.Start();
                        break;
                    case Keys.Left:
                    case Keys.A:
                        timerL.Start();
                        break;
                    case Keys.Down:
                    case Keys.S:
                        timerD.Start();
                        break;
                    case Keys.Right:
                    case Keys.D:
                        timerR.Start();
                        break;
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            timerU.Stop();
            timerD.Stop();
            timerL.Stop();
            timerR.Stop();

            if (e.KeyCode == Keys.Space)
            {
                if (!gameOver)
                {
                    if (pause)
                    {
                        StartTimers();
                        lblGameOver.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        lblGameOver.Location = new Point(this.Width / 2 - 120, 150);
                        lblGameOver.Text = "ΠΑΥΣΗ";
                        lblGameOver.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            MainForm_Load(e, e);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void lblCredits_Click(object sender, EventArgs e)
        {
            Form creds = new Credits();
            creds.Show();
        }
        #endregion

        #region Helpers
        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void Collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();

                    score += 1;
                    lblScore.Text = (score < 10) ? "ΣΚΟΡ: 0" + score.ToString() : "ΣΚΟΡ: " + score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        lblLevel.Text = (level < 10) ? "ΕΠΙΠΕΔΟ: 0" + level.ToString() : "ΕΠΙΠΕΔΟ: " + level.ToString();

                        if (enemySpeed <= 10 && enemiesMunSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemySpeed++;
                            enemiesMunSpeed++;
                        }

                        if (level == 10)
                        {
                            lblGameOver.Location = new Point(71, 123);
                            GameOver("ΣΥΓΧΑΡΗΤΗΡΙΑ!");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }

                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    lblGameOver.Location = new Point(71, 123);
                    GameOver("ΤΕΛΟΣ ΠΑΙΧΝΙΔΙΟΥ");
                }
            }
        }

        private void CollisionWithMun()
        {
            for (int i = 0; i < enemiesMun.Length; i++)
            {
                if (enemiesMun[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemiesMun[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("ΤΕΛΟΣ ΠΑΙΧΝΙΔΙΟΥ");
                }
            }
        }

        private void GameOver(string str)
        {
            lblGameOver.Text = str;
            lblGameOver.Visible = true;
            lblCredits.Visible = true;
            btnRestart.Visible = true;
            btnQuit.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        private void StopTimers()
        {
            bgTimer.Stop();
            enemyTimer.Stop();
            timerMun.Stop();
            timerMunEnemy.Stop();
        }

        private void StartTimers()
        {
            bgTimer.Start();
            enemyTimer.Start();
            timerMun.Start();
            timerMunEnemy.Start();
        }
        #endregion
    }
}
