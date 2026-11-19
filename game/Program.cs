using game;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PISPraktika1
{
    class Program
    {
        static void Main()
        {
            var level = new Level();
            level.Load("level.txt");

            var start = level.Find('@');
            var player = new Player(start.x, start.y);
          
            new Renderer().Draw(level, player);
        }
    }
}