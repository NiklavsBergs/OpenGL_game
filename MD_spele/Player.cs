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
using System.Diagnostics;

namespace MD_spele
{
    internal class Player
    {
        Random random = new Random();

        public float X { get; set;  }
        public float Y { get; set;  }
        public int Health { get; set; }
        public int Points { get; set; }
        public int GameMode { get; set; }
        public float Rotation { get; set; }
        public bool boss { get; set; }
        public int Level { get; set; }

        int enemiesSpawned = 0;

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
            boss = false;

        }

        public Player(int gameMode)
        {
            Rotation = 0;
            Points = 0;
            GameMode = gameMode;
            Image = new Bitmap(@"Images\player.png");
            X = 0;
            Y = 0;
            boss = false;
            Level = 1;
            if (gameMode == 1)
            {
                Health = 3;
            }
            else if (gameMode == 2)
            {
                Health = 3;
            }
            else if (gameMode == 3)
            {
                Health = 1;
            }

        }

        public void AddPoint()
        {
            Points++;
        }

        public void AddPoints(int points)
        {
            Points = Points + points;
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
            gl.Translate(screenCenterX, screenCenterY, 0.0f);
            gl.Rotate(-Rotation, 0.0f, 0.0f, 1.0f);

            Texture texture = new Texture();
            texture.Create(gl, Image);

            gl.Scale(0.5, 0.5, 1);
            gl.Color(1.0f, 1.0f, 1.0f, 1.0f);

            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

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
        public void SpawnEnemies()
        {
            //Levels
            if (GameMode == 1)
            {
                if(Level == 1)
                {
                    if (enemies.Count() < 4)
                    {
                        Spawn(400);

                    }
                }
                if (Level > 1) 
                {
                    if (enemies.Count() < 5)
                    {
                        Spawn(400);
                    }
                }
                
            }

            //Endless
            else if (GameMode == 2)
            {
                if (enemies.Count() < 6)
                {
                    Spawn(400);
                }
                if (enemiesSpawned % 8 == 0)
                {
                    SpawnBoss();
                }
            }

            //Expert
            else if (GameMode == 3)
            {
                if (enemies.Count() < 5)
                {
                    Spawn(400);
                }
                if (enemiesSpawned % 8 == 0)
                {
                    SpawnBoss();
                }
            }
        }

        public void Spawn(int minDistance)
        {
            // Distance from player
            float distance = random.Next(minDistance, 1000);
            // Angle from player (radians)
            float angle = (float)random.NextDouble() * 2 * (float)Math.PI;

            float enemyX = X + distance * (float)Math.Cos(angle);
            float enemyY = Y + distance * (float)Math.Sin(angle);

            int color = random.Next(1, 5);
            Enemy newEnemy = new Enemy(enemyX, enemyY, 3.0f, 20, X, Y, color);
            enemies.Add(newEnemy);
            enemiesSpawned++;
        }

        public void SpawnBoss()
        {
            float distance = random.Next(1000, 1000);
            float angle = (float)random.NextDouble() * 2 * (float)Math.PI;

            float enemyX = X + distance * (float)Math.Cos(angle);
            float enemyY = Y + distance * (float)Math.Sin(angle);

            int color = random.Next(1, 5);
            if(GameMode == 1)
            {
                if (Level == 1)
                {
                    Boss newBoss = new Boss(enemyX, enemyY, 2.0f, 40, X, Y, 1, 4);
                    enemies.Add(newBoss);
                    boss = true;
                    enemiesSpawned++;
                }
                else
                {
                    Boss newBoss = new Boss(enemyX, enemyY, 2.0f, 40, X, Y, 1, 6);
                    enemies.Add(newBoss);
                    boss = true;
                    enemiesSpawned++;
                }
            }
            else
            {
                Boss newBoss = new Boss(enemyX, enemyY, 2.0f, 30, X, Y, 1, 3);
                enemies.Add(newBoss);
                enemiesSpawned++;
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
                
                gl.Translate(enemy.X, enemy.Y, 0.0f);

                Texture texture = new Texture();
                texture.Create(gl, Image);

                gl.Scale(enemy.Size/40, enemy.Size/40, 1);
                gl.Rotate(enemy.Rotation, 0.0f, 0.0f, 1.0f);

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
                gl.Translate(bullet.X, bullet.Y, 0.0f);

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

        //Checks if any bullets collide with enemies
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
                            if (enemies[j] is Boss bossEnemy)
                            {
                                bullets.RemoveAt(i);
                                bossEnemy.damage();
                                if (bossEnemy.Lives == 0)
                                {
                                    enemies.RemoveAt(j);
                                    PlayPointSound();
                                    AddPoints(5);
                                    boss = false;
                                    Level++;
                                }
                            }
                            else
                            {
                                PlayPointSound();
                                bullets.RemoveAt(i);
                                enemies.RemoveAt(j);
                                AddPoint();
                            }
                        }

                        else if (GameMode == 3)
                        {
                            bullets.RemoveAt(i);
                            Health = Health - 1;
                            PlayHurtSound();
                        }
                        break;
                    }
                }
            }
        }

        //Checks if any enemies colide with player
        public void CheckPlayerCollisions()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].HasHitPlayer(this))
                {
                    if (enemies[i] is Boss)
                    {
                        Health = Health - 3;
                        enemies.RemoveAt(i);
                        PlayHurtSound();
                    }
                    else
                    {
                        Health = Health - 1;
                        enemies.RemoveAt(i);
                        PlayHurtSound();
                    }
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
