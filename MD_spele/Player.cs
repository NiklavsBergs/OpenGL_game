using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpGL.SceneGraph.Assets;
using static System.Net.Mime.MediaTypeNames;
using SharpGL.SceneGraph;
using System.Linq.Expressions;
using System.Media;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MD_spele
{
    internal class Player
    {
        public float X { get; set;  }
        public float Y { get; set;  }
        public int Health { get; set; }
        public int Points { get; set; }
        public float Rotation { get; set; }

        public Bitmap Image { get; set; }

        List<Enemy> enemies = new List<Enemy>();

        List<Bullet> bullets = new List<Bullet>();

        public Player(int health, float screenCenterX, float screenCenterY)
        {
            Rotation = 0;
            Points = 0;
            Health = health;
            Image = new Bitmap(@"Images\player.png");
            X = screenCenterX;
            Y = screenCenterY;

        }

        public Player(int health)
        {
            Rotation = 0;
            Points = 0;
            Health = health;
            Image = new Bitmap(@"Images/player.png");
            X = 0;
            Y = 0;

        }

        public void AddPoint()
        {
            Points++;
        }

        public void Draw()
        {

        }
        
        public void DrawPlayer(OpenGL gl, float screenCenterX, float screenCenterY)
        {
            Image = new Bitmap(@"Images\player.png");

            float halfWidth = Image.Width / 2.0f;
            float halfHeight = Image.Height / 2.0f;

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            gl.PushMatrix();
            gl.Translate(screenCenterX, screenCenterY, 0.0f); // Move to the center of the screen
            gl.Rotate(-Rotation, 0.0f, 0.0f, 1.0f); // Rotate player according to mouse position

            Texture texture = new Texture();
            texture.Create(gl, Image);

            gl.Scale(0.5, 0.5, 1);
            gl.Color(1.0f, 1.0f, 1.0f, 1.0f);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            // Draw the player texture
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-halfWidth, -halfHeight);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(halfWidth, -halfHeight);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(halfWidth, halfHeight);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-halfWidth, halfHeight);
            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            texture.Destroy(gl);

            gl.PopMatrix();
        }
        public void SpawnEnemies(int numberOfEnemies)
        {
            Random random = new Random();

            if (enemies.Count() < numberOfEnemies)
            {
                // Set random positions around the player within a certain distance (adjust range as needed)
                
                float distance = random.Next(200, 1000); // Example distance from player
                float angle = (float)random.NextDouble() * 2 * (float)Math.PI;

                float enemyX = X + distance * (float)Math.Cos(angle);
                float enemyY = Y + distance * (float)Math.Sin(angle);

                // Create an enemy and add it to the list
                int color = random.Next(1, 5);
                Enemy newEnemy = new Enemy(enemyX, enemyY, 3.0f, 20, X, Y, color);
                enemies.Add(newEnemy);
                
            }
        }

        public void RenderEnemies(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
            foreach (var enemy in enemies)
            {
                switch (enemy.color)
                {
                    case 1:
                        gl.Color(1.0f, 1.0f, 0.0f);
                        break;
                    case 2:
                        gl.Color(1.0f, 0.0f, 0.0f);
                        break;
                    case 3:
                        gl.Color(0.0f, 1.0f, 0.0f);
                        break;
                    case 4:
                        gl.Color(0.0f, 0.0f, 1.0f);
                        break;
                    default:
                        gl.Color(1.0f, 1.0f, 1.0f);
                        break;
                }

                enemy.UpdatePos(X, Y);

                Image = new Bitmap(@"Images\enemy.png");

                float halfWidth = Image.Width / 2.0f;
                float halfHeight = Image.Height / 2.0f;

                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.LoadIdentity();

                gl.PushMatrix();
                
                gl.Translate(enemy.X, enemy.Y, 0.0f); // Translate to the enemy position

               

                Texture texture = new Texture();
                texture.Create(gl, Image);

                gl.Scale(0.5, 0.5, 1);
                gl.Rotate(enemy.Rotation, 0.0f, 0.0f, 1.0f);

                // Draw the enemy texture
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Bind(gl);
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(-halfWidth, -halfHeight);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(halfWidth, -halfHeight);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(halfWidth, halfHeight);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(-halfWidth, halfHeight);
                gl.End();
                gl.Disable(OpenGL.GL_TEXTURE_2D);

                texture.Destroy(gl);
          
                gl.PopMatrix();
            }
            gl.End();
        }

        public void AddBullet(Bullet bullet)
        {
            bullets.Add(bullet);
        }

        public void RenderBullets(OpenGL gl)
        {

            foreach (var bullet in bullets)
            {
                // Set color
                switch (bullet.color)
                {
                    case 1:
                        gl.Color(1.0f, 1.0f, 0.0f);
                        break;
                    case 2:
                        gl.Color(1.0f, 0.0f, 0.0f);
                        break;
                    case 3:
                        gl.Color(0.0f, 1.0f, 0.0f);
                        break;
                    case 4:
                        gl.Color(0.0f, 0.0f, 1.0f);
                        break;
                    default:
                        gl.Color(1.0f, 1.0f, 1.0f);
                        break;
                }

                bullet.Update();

                gl.PushMatrix();
                gl.Translate(bullet.X, bullet.Y, 0.0f); // Translate to the bullet position

                // Draw the bullet (small circle)
                gl.Begin(OpenGL.GL_POLYGON);
                for (int i = 0; i < 360; i += 10)
                {
                    float angle = (float)i * (float)Math.PI / 180.0f;
                    float x = (float)Math.Cos(angle) * 3.0f; 
                    float y = (float)Math.Sin(angle) * 3.0f;
                    gl.Vertex(x, y);
                }
                gl.End();

                gl.PopMatrix();
            }
        }

        public void CheckCollisions()
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (bullets[i].HasHitEnemy(enemies[j]))
                    {
                        if (bullets[i].color == enemies[j].color)
                        {
                            PlayPointSound();
                            bullets.RemoveAt(i); 
                            enemies.RemoveAt(j); 
                            AddPoint();
                            
                        }
                        else
                        {
                            bullets.RemoveAt(i);
                            Health = Health - 1;
                        }
                        
                        break;
                    }
                }
            }
        }

        public void CheckPlayerCollisions()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].HasHitPlayer(this))
                {
                    Health = Health - 1; 
                    enemies.RemoveAt(i);
                    PlayHurtSound();

                }
            }
        }

        private void PlayHurtSound()
        {
            var hurtSound = new AudioFileReader(@"Sounds/hurt.wav");
            var hurtOutputDevice = new WaveOutEvent();

            hurtOutputDevice.Init(hurtSound);
            hurtOutputDevice.Volume = 0.5f;
            hurtOutputDevice.Play();
        }

        private void PlayPointSound()
        {
            var pointSound = new AudioFileReader(@"Sounds/point.wav");
            var pointOutputDevice = new WaveOutEvent();

            pointOutputDevice.Init(pointSound);
            pointOutputDevice.Volume = 0.5f;
            pointOutputDevice.Play();
        }
    }
}
