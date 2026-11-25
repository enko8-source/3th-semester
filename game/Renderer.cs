using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Renderer
    {
        public int Radius = 5;

        public void Draw(Level level, Player player, Spider spider)
        {

            for (int dy = -Radius; dy <= Radius; dy++)
            {
                for (int dx = -Radius; dx <= Radius; dx++)
                {
                    int xp = player.X + dx;
                    int yp = player.Y + dy;


                    if (dx == 0 && dy == 0)
                    {
                        Console.Write('@');
                        continue;
                    }

                    if (xp < 0 || yp < 0 || xp >= level.Width || yp >= level.Height)
                    {
                        Console.Write(' ');
                        continue;
                    }

                    Console.Write(level.Get(xp, yp));
                }
                Console.WriteLine();
            }
        }
    }
}

