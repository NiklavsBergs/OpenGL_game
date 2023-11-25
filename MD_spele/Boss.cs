using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD_spele
{
    internal class Boss : Enemy
    {
        Random random = new Random();

        public int[] Colors { get; set; }
        public int Lives;

        public Boss(float x, float y, float speed, float size, float px, float py, int color, int lives) : base(x, y, speed, size, px, py, color)
        {
            Lives = lives;
            Colors = new int[Lives];
            for (int i = 0; i<lives-1; i++)
            {
                Colors[i] = random.Next(1, 5);
            }

            color = Colors[Lives-1];
        }

        public void damage()
        {
            if (Lives>1)
            {
                Lives--;
                color = Colors[Lives - 1];
            }
            else if (Lives == 1)
            {
                Lives--;
            }
        }
    }
}
