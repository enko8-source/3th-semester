using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Player
    {
        public int X, Y;
        public Player(int x, int y) { X = x; Y = y; }
        Inventory inventory = new Inventory();
        public void Move (string direction)
        {
            if (direction=="w")
            {
                Y -= 1;
            }
            if (direction == "s")
            {
                Y += 1;
            }
            if (direction == "d")
            {
                X += 1;
            }
            if (direction == "a")
            {
                X -= 1;
            }
        }
    }
}
