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

namespace MD_spele
{
    internal class Player
    {
        public float X { get; }
        public float Y { get; }
        public int Health { get; set; }
        public int Points { get; set; }

        //public Bitmap Image { get; set; }

        public Player(int health)
        {
            X = 0.0f;
            Y = 0.0f;
            Points = 0;
            Health = health;
            //Image = image;
        }

        public void AddPoint()
        {
            Points++;
        }

        public void Draw()
        {

        }
        /*
        public void DrawHeart(OpenGL gl)
        {
            Texture texture = new Texture();
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            texture.Create(gl, @"C:\Users\Niklavs\source\repos\MD_spele\MD_spele\heart.png");
            texture.Bind(gl);

            gl.Begin(OpenGL.GL_QUADS);
            
            gl.TexCoord(0.0f, 0.0f); gl.Vertex(x, y);
            gl.TexCoord(1.0f, 0.0f); gl.Vertex(x + image.Width, y);
            gl.TexCoord(1.0f, 1.0f); gl.Vertex(x + image.Width, y + image.Height);
            gl.TexCoord(0.0f, 1.0f); gl.Vertex(x, y + image.Height);
            gl.End();

        }*/
    }
}
