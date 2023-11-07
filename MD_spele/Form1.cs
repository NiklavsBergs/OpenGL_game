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

namespace MD_spele
{
    public partial class Form1 : Form
    {
        private float playerRotation = 0.0f;
        private float screenCenterX, screenCenterY;
        float deltaX;
        float deltaY;

        int gameMode = 1;

        int chosenColor = 1;

        bool isGameRunning = true;

        int difficulty = 1;

        static string shootSoundFilePath = "Sounds/shoot3.wav";
        
        
      
        
        //static Bitmap playerTexture = new Bitmap(@"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\player.png");

        Bitmap image = new Bitmap(@"Images/heart.png");
        float width;
        float height;

        Player p1 = new Player(4);

        public Form1()
        {

            InitializeComponent();
            height = image.Height;
            width = image.Width;



            playBackgroundMusic();


        }


        private void openGLControl2_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            if (p1.Health > 0)
            {
                screenCenterX = openGLControl2.Width / 2.0f;
                screenCenterY = openGLControl2.Height / 2.0f;

                p1.X = screenCenterX;
                p1.Y = screenCenterY;

                OpenGL gl = new OpenGL();

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

                gl.Translate(screenCenterX, screenCenterY, 0.0f);

                renderHearts(gl, p1, image);

                p1.SpawnEnemies(4);

                p1.DrawPlayer(gl, screenCenterX, screenCenterY);

                p1.RenderEnemies(gl);

                p1.RenderBullets(gl);

                p1.CheckCollisions();

                p1.CheckPlayerCollisions();

                p1.SpawnEnemies(4);

                labelPoints.Text = p1.Points.ToString();
            }
            else
            {
                isGameRunning = false;
                labelOver.Text = "Game over!";
                labelScore.Text = "Score: " + p1.Points;
                buttonRetry.Visible = true;
                buttonQuit.Visible = true;
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

            // Enable texturing
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);

            float x;
            float y;

            gl.PushMatrix();

            // Draw the heart icon
            
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

        private void DrawHeart(Bitmap image, float x, float y, OpenGL gl)
        {
            // Convert the Bitmap to a texture
            Bitmap heart = new Bitmap(@"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\heart.png");
            Texture texture = new Texture();
            texture.Create(gl, heart);


            // Set up the orthographic projection for 2D rendering
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(0, openGLControl2.Width, 0, openGLControl2.Height, -1, 1);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            // Enable texturing
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);

            // Draw the heart icon
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(x, y);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(x + image.Width/20, y);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(x + image.Width/20, y + image.Height/20);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(x, y + image.Height/20);
            gl.End();

            // Clean up
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            texture.Destroy(gl);
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
            p1 = new Player(4);
            labelOver.Text = "";
            labelScore.Text = "";
            buttonRetry.Visible = false;
            buttonQuit.Visible = false;
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
