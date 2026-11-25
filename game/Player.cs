using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Player
    {
        public int X, Y;
        public Player(int x, int y) { X = x; Y = y; }

        public void Move(string direction)
        {
            Console.Clear();
            
            if (direction =="d")
            {
                X += 1;
            }
            else if (direction =="s")
            {
                Y += 1;
            }
            else if (direction =="a")
            {
                X -= 1;
            }
            else if (direction =="w")
            {
                Y-=1;
            }
        }
    }
}
