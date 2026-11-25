using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class Level
    {
        public int Width, Height;
        public char[,] Map;

        public void Load(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Height = lines.Length;
            Width = lines[0].Length;
            Map = new char[Width, Height];

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Map[x, y] = lines[y][x];
        }

        public char Get(int x, int y) => Map[x, y];

        public (int x, int y) Find(char c)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (Map[x, y] == c) return (x, y);
            return (-1, -1);
        }

        public void Save(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int y = 0; y < Height; y++)
                    for (int x = 0; x < Width; x++)
                    {
                        writer.Write(Get(x, y));
                    }
            }
        }
    }
}

