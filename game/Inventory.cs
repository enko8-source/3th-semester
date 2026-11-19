using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    public class Inventory
    {
        internal int MaxSpace = 3;
        internal bool IsTorch = false;
        internal bool IsAxe = false;
        public int Space = 0;
        
        public bool Add(int x, int y, string type)
        {
            Object oobject = new Object(x, y, type);
            if (Space<MaxSpace)
            {
                if (oobject.X == x && oobject.Y == y)
                {
                    Space += 1;
                    if (oobject.Type == "Т")
                    {
                        return IsTorch=true;
                    }
                    if (oobject.Type == "A")
                    {
                        return IsAxe = true;
                    }
                    return false;
                }
                return false;

            }
            return false;

        }

    }
}
