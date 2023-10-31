using SharpGL;
using SharpGL.SceneGraph;
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
        public float Speed { get; set; }
        public Bitmap Image { get; set; }

        public Enemy(float x, float y, float speed, Bitmap image)
        {
            X = x;
            Y = y;
            Speed = speed;
            Image = image;
        }

        public void UpdatePos(Player player)
        {
            // Calculate direction towards the player
            float directionX = player.X - X;
            float directionY = player.Y - Y;
            float distanceToPlayer = (float)Math.Sqrt(directionX * directionX + directionY * directionY);

            // Move towards the player by adjusting position based on direction and speed
            if (distanceToPlayer > 0)
            {
                float moveX = (directionX / distanceToPlayer) * Speed;
                float moveY = (directionY / distanceToPlayer) * Speed;

                X += moveX;
                Y += moveY;
            }
        }

    }
}
