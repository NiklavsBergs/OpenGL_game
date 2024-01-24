using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Lighting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_spele
{
    internal class Enemy
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float pX { get; set; }
        public float pY { get; set; }
        public float Speed { get; set; }
        public Bitmap Image { get; set; }

        public int color { get; set; }

        public float Size { get; set; }

        public float Rotation { get; set; }

        public Enemy(float x, float y, float speed, float size, float px, float py, int color)
        {
            X = x;
            Y = y;
            Speed = speed;
            Size = size;
            pX = px; 
            pY = py;
            this.color = color;
            Rotation = 0f;

            //Image = image;
        }

        public void UpdatePos(float plX, float plY)
        {
            
            // Calculate direction towards the player
            float directionX = plX - X;
            float directionY = plY - Y;
            float distanceToPlayer = (float)Math.Sqrt(directionX * directionX + directionY * directionY);

            Rotation = (float)(Math.Atan2(directionY, directionX) * (180 / Math.PI)) + 90;

            // Move towards the player by adjusting position based on direction and speed
            if (distanceToPlayer > 0)
            {
                float moveX = (directionX / distanceToPlayer) * Speed;
                float moveY = (directionY / distanceToPlayer) * Speed;

                X += moveX;
                Y += moveY;
            }
           
        }

        public bool HasHitPlayer(Player player)
        {
            // Check if enemy box collides with the player's bounding box
            return (X - Size / 2 < player.X + 50 / 2 &&
                    X + Size / 2 > player.X - 50 / 2 &&
                    Y - Size / 2 < player.Y + 50 / 2 &&
                    Y + Size / 2 > player.Y - 50 / 2);
        }

    }
}
