using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using SharpGL.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Media;
using NAudio.Wave;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace MD_spele
{
    public partial class Form1 : Form
    {
        private float playerRotation = 0.0f;
        private float screenCenterX, screenCenterY;
        float deltaX;
        float deltaY;

        int gameMode = 1;
        bool modeChosen = false;
        bool isGameRunning = false;
        bool boss = false;
        bool level1Displayed = false;
        bool level2Displayed = false;
        bool win = false;
        bool gamePause = false;

        int chosenColor = 1;

        static string shootSoundFilePath = "Sounds/shoot3.wav";

        Bitmap image = new Bitmap(@"Images/heart.png");
        float width;
        float height;

        Player p1 = new Player(1);

        public Form1()
        {

            InitializeComponent();
            height = image.Height;
            width = image.Width;
            playBackgroundMusic();

        }


        private void openGLControl2_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            if (isGameRunning & modeChosen)
            {
                if(gameMode == 1)
                {
                    if (!level1Displayed)
                    {
                        labelLevel.Text = "Level 1";
                        gamePause = true;
                        timerLevel.Enabled = true;
                        level1Displayed = true;
                        
                    }
                    else if (p1.Points == 20 & !p1.boss)
                    {
                        labelLevel.Text = "Boss";
                        p1.SpawnBoss();
                        timerLevel.Enabled = true;
                    }
                    else if (p1.Points >= 25 & !level2Displayed)
                    {
                        labelLevel.Text = "Level 2";
                        gamePause = true;
                        timerLevel.Enabled = true;
                        level2Displayed = true;
                    }

                    else if (p1.Points == 45 & !p1.boss)
                    {
                        labelLevel.Text = "Boss";
                        p1.SpawnBoss();
                        timerLevel.Enabled = true;
                    }
                    else if (p1.Points >= 50)
                    {
                        win = true;
                        isGameRunning = false;
                    }

                }

                screenCenterX = openGLControl2.Width / 2.0f;
                screenCenterY = openGLControl2.Height / 2.0f;

                p1.X = screenCenterX;
                p1.Y = screenCenterY;

                OpenGL gl = new OpenGL();

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                gl.Translate(screenCenterX, screenCenterY, 0.0f);

                renderHearts(gl, p1, image);

                if (!p1.boss && !gamePause)
                {
                    p1.SpawnEnemies();
                }

                p1.DrawPlayer(gl, screenCenterX, screenCenterY);

                p1.RenderEnemies(gl);

                p1.RenderBullets(gl);

                p1.CheckCollisions();

                p1.CheckPlayerCollisions();

                labelPoints.Text = p1.Points.ToString();

                if (p1.Health <= 0)
                {
                    isGameRunning = false;
                }
            }
            else if (!modeChosen)
            {
                buttonModeLevels.Visible = true;
                buttonModeEndless.Visible = true;
                buttonModeExpert.Visible = true;
            }
            else if (win)
            {
                labelOver.Text = "You won!";
                labelScore.Text = "Score: " + p1.Points;
                buttonQuit.Visible = true;
                buttonChangeMode.Visible = true;
            }
            else
            {
                labelOver.Text = "Game over!";
                labelScore.Text = "Score: " + p1.Points;
                buttonRetry.Visible = true;
                buttonQuit.Visible = true;
                buttonChangeMode.Visible = true;
            }

        }

        private void renderHearts(OpenGL gl, Player p1, Bitmap image)
        {
            Texture texture = new Texture();

            texture.Create(gl, @"Images/heart.png");

            

            // Set up the orthographic projection for 2D rendering
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(0, openGLControl2.Width, 0, openGLControl2.Height, -1, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

           
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);

            float x;
            float y;

            gl.PushMatrix();
            
            gl.Begin(OpenGL.GL_QUADS);


            for (int i = 0; i < p1.Health; i++)
            {
                x = i * (width / 20 + 10);
                y = openGLControl2.Height - height / 20;

                gl.TexCoord(0.0f, 1.0f); gl.Vertex(x, y);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(x + width / 20, y);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(x + width / 20, y + height / 20);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(x, y + height / 20);

            }

            gl.End();

            gl.PopMatrix();

            gl.Disable(OpenGL.GL_TEXTURE_2D);
            texture.Destroy(gl);
        }

        private void openGLControl2_MouseMove(object sender, MouseEventArgs e)
        {
            deltaX = e.X - screenCenterX;
            deltaY = e.Y - screenCenterY;

            playerRotation = (float)(Math.Atan2(deltaY, deltaX) * (180.0 / Math.PI));

            p1.Rotation = playerRotation;
        }

        private void openGLControl2_MouseClick(object sender, MouseEventArgs e)
        {
            if (isGameRunning)
            {
                float distance = (float)Math.Sqrt((e.X - p1.X) * (e.X - p1.X) + (e.Y - p1.Y) * (e.Y - p1.Y));
                // Calculate direction from player to mouse
                float directionX = (e.X - p1.X) / distance;
                float directionY = (e.Y - p1.Y) / distance;


                // Create a new bullet and add it to the list
                p1.AddBullet(new Bullet(p1.X, p1.Y, directionX, -directionY, 15, chosenColor));

                Task.Run(() => PlayShootSound());
                
            }
            
        }

        private void PlayShootSound()
        {
            var shootSound = new AudioFileReader(@"Sounds/shoot.wav");
            var shootOutputDevice = new WaveOutEvent();

            shootOutputDevice.Init(shootSound);
            shootOutputDevice.Volume = 0.5f;
            shootOutputDevice.Play();
        }

        private void openGLControl2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 119)
            {
                chosenColor = 1;
                buttonW.FlatStyle = FlatStyle.Standard;
                buttonA.FlatStyle = FlatStyle.Flat;
                buttonS.FlatStyle = FlatStyle.Flat;
                buttonD.FlatStyle = FlatStyle.Flat;
            }
            else if (e.KeyChar == 97)
            {
                chosenColor = 2;
                buttonA.FlatStyle = FlatStyle.Standard;
                buttonW.FlatStyle = FlatStyle.Flat;
                buttonS.FlatStyle = FlatStyle.Flat;
                buttonD.FlatStyle = FlatStyle.Flat;
            }

            else if (e.KeyChar == 115)
            {
                chosenColor = 3;
                buttonS.FlatStyle = FlatStyle.Standard;
                buttonW.FlatStyle = FlatStyle.Flat;
                buttonA.FlatStyle = FlatStyle.Flat;
                buttonD.FlatStyle = FlatStyle.Flat;
            }
            else if (e.KeyChar == 100)
            {
                chosenColor = 4;
                buttonD.FlatStyle = FlatStyle.Standard;
                buttonW.FlatStyle = FlatStyle.Flat;
                buttonS.FlatStyle = FlatStyle.Flat;
                buttonA.FlatStyle = FlatStyle.Flat;
            }
        }

        private void labelOver_Click(object sender, EventArgs e)
        {

        }

        private void buttonRetry_Click(object sender, EventArgs e)
        {
            isGameRunning = true;
            win = false;
            p1 = new Player(gameMode);
            labelOver.Text = "";
            labelScore.Text = "";
            buttonRetry.Visible = false;
            buttonQuit.Visible = false;
            buttonChangeMode.Visible = false;
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openGLControl2_Load(object sender, EventArgs e)
        {

        }

        private void buttonModeLevels_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            modeChosen = true;
            isGameRunning = true;
            win = false;
            buttonModeLevels.Visible = false;
            buttonModeEndless.Visible = false;
            buttonModeExpert.Visible = false;
            p1 = new Player(gameMode);
        }

        private void buttonModeEndless_Click(object sender, EventArgs e)
        {
            gameMode = 2;
            modeChosen = true;
            isGameRunning = true;
            win = false;
            buttonModeLevels.Visible = false;
            buttonModeEndless.Visible = false;
            buttonModeExpert.Visible = false;
            p1 = new Player(gameMode);
        }

        private void buttonModeExpert_Click(object sender, EventArgs e)
        {
            gameMode = 3;
            modeChosen = true;
            isGameRunning = true;
            win = false;
            buttonModeLevels.Visible = false;
            buttonModeEndless.Visible = false;
            buttonModeExpert.Visible = false;
            p1 = new Player(gameMode);
        }

        private void buttonChangeMode_Click(object sender, EventArgs e)
        {
            modeChosen = false;
            buttonModeLevels.Visible = true;
            buttonModeEndless.Visible = true;
            buttonModeExpert.Visible = true;
            buttonRetry.Visible = false;
            buttonChangeMode.Visible = false;
            buttonQuit.Visible = false;
            labelOver.Text = "";
            labelScore.Text = "";
        }

        private void timerLevel_Tick(object sender, EventArgs e)
        {
            labelLevel.Text = "";
            timerLevel.Enabled = false;
            gamePause = false;
        }

        async void DisplayLevelMessage(string message, int duration)
        {
            gamePause = true;
            labelLevel.Text = message;

            Timer displayTimer = new Timer();
            displayTimer.Interval = duration;
            displayTimer.Tick += (sender, e) =>
            {
                labelLevel.Text = "";
                gamePause = false;
                displayTimer.Stop();
                displayTimer.Dispose(); // Cleanup the timer
            };

            displayTimer.Start();
        }

        private void playBackgroundMusic()
        {
            Task.Run(() =>
            {
                var backgroundMusic = new AudioFileReader(@"Sounds/background.wav");
                var backgroundOutputDevice = new WaveOutEvent();

                backgroundOutputDevice.Init(backgroundMusic);
                backgroundOutputDevice.Volume = 0.5f;
                
                while (true)
                {
                    backgroundMusic.Position = 0;
                    backgroundOutputDevice.Play();
                    Thread.Sleep(110000);
                }


            });
        }




    }
}
