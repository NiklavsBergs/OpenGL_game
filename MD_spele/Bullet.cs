using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_spele
{

    internal class Bullet
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float DirectionX { get; set; }
        public float DirectionY { get; set; }
        public float Speed { get; set; }

        public int color { get; set; }

        public Bullet(float x, float y, float directionX, float directionY, float speed, int color)
        {
            X = x;
            Y = y;
            DirectionX = directionX;
            DirectionY = directionY;
            Speed = speed;
            this.color = color;
        }

        public void Update()
        {
            X += DirectionX * Speed;
            Y += DirectionY * Speed;
        }

        public bool HasHitEnemy(Enemy enemy)
        {
            // Check if the bullet's position is within the enemy's bounding box
            return (X > enemy.X - enemy.Size && X < enemy.X + enemy.Size &&
                    Y > enemy.Y - enemy.Size && Y < enemy.Y + enemy.Size);
        }
    }
}
