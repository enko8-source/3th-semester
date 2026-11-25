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
            var onceLevel= new Level();
            level.Load("level.txt");

            var start = level.Find('@');
            var player = new Player(start.x, start.y);
            var spider = new Spider(start.x, start.y);
            var torch = new Torch(start.x, start.y);

            var renderer = new Renderer();
            renderer.Draw(level, player, spider);

            while (true)
            {
                Console.WriteLine("Введите движение");
                string direction = Console.ReadLine();
                if (direction == "q")
                {
                    break;
                }
                else if (direction == "w" || direction== "a" || direction == "s" || direction == "d")
                {
                    player.Move(direction);
                    renderer.Draw(level, player, spider);
                    onceLevel.Save("Step.txt");
                } 
            }
        }
    }
}