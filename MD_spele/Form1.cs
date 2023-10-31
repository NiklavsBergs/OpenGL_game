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

namespace MD_spele
{
    public partial class Form1 : Form
    {
        private float playerRotation = 0.0f;
        private float screenCenterX, screenCenterY;
        
        //static Bitmap playerTexture = new Bitmap(@"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\player.png");

        Player p1 = new Player(4);

        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void openGLControl2_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            screenCenterX = openGLControl2.Width / 2.0f;
            screenCenterY = openGLControl2.Height / 2.0f;

            OpenGL gl = new OpenGL();

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            renderHearts(gl, p1);

            renderPlayer(gl);

        }

        private void renderHearts(OpenGL gl, Player p1)
        {
            Bitmap heartIcon = new Bitmap(@"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\heart.png");

            for (int i = 0; i < p1.Health; i++)
            {
                float heartX = i * (heartIcon.Width / 20 + 10); // Adjust the spacing as needed
                float heartY = openGLControl2.Height - heartIcon.Height / 20;
                DrawHeart(heartIcon, heartX, heartY, gl);
            }
        }

        private void openGLControl2_MouseMove(object sender, MouseEventArgs e)
        {
            float deltaX = e.X - screenCenterX;
            float deltaY = e.Y - screenCenterY;

            playerRotation = (float)(Math.Atan2(deltaY, deltaX) * (180.0 / Math.PI));
        }

        private void DrawHeart(Bitmap image, float x, float y, OpenGL gl)
        {
            // Convert the Bitmap to a texture
            Texture texture = new Texture();
            texture.Create(gl, @"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\heart.png");

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

        private void renderPlayer(OpenGL gl)
        {
            Bitmap playerImage = new Bitmap(@"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\player.png");

            float halfWidth = playerImage.Width / 2.0f;
            float halfHeight = playerImage.Height / 2.0f;

            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            gl.PushMatrix();
            gl.Translate(screenCenterX, screenCenterY, 0.0f); // Move to the center of the screen
            gl.Rotate(-playerRotation, 0.0f, 0.0f, 1.0f); // Rotate player according to mouse position

            DrawPlayer(playerImage, gl, halfHeight, halfWidth);

            gl.PopMatrix();

            
        }

        private void DrawPlayer(Bitmap image, OpenGL gl, float halfWidth, float halfHeight)
        {
            
            Texture texture = new Texture();
            texture.Create(gl, image);

            gl.Color(1.0f, 1.0f, 1.0f, 1.0f);

            // Draw the player texture
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Bind(gl);
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(-halfHeight, -halfWidth);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(halfHeight, -halfWidth);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(halfHeight, halfWidth);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(-halfHeight, halfWidth);
            gl.End();
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            texture.Destroy(gl);
        }
    }
}
