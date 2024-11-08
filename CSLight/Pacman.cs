using System;
using System.IO;

namespace CSLight
{

    internal class Pacman
    {
        public void drawmap(char[,] map)
        {
            int k = 0;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (map[i, j] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (map[i, j] == '.')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        k += 1;
                    }
                    if (map[i, j] == 'Q')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(map[i, j]);
                    

                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
            }
            if (k == 0) { 
                Console.WriteLine("WIN");
                Console.ReadKey();
            }

            
        }
        virtual public void key(ConsoleKeyInfo keyinfo)
        {
      
          
            switch (keyinfo.Key)
            {
                case ConsoleKey.DownArrow:
                    if (map[x + 1, y] != '#')
                    {
                        d = Direction.Down;
                        x += 1;
                        this.move(x, y, map, d);
                    }
              
                    break;


                case ConsoleKey.UpArrow:
                    if (map[x - 1, y] != '#')
                    {
                        d = Direction.Up;
                        x -= 1;
                        this.move(x, y, map, d);
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (map[x, y + 1] != '#')
                    {
                        d = Direction.Right;
                        y += 1;
                        this.move(x, y, map, d);
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (map[x, y - 1] != '#')
                    {
                        d = Direction.Left;
                        y -= 1;
                        this.move(x, y, map, d);
                    }
                    break;

            }
           
        }
        virtual public void move(int x, int y, char[,] arr, Direction d)
        {
            arr[x, y] = '@';
            if (d == Direction.Down) arr[x - 1, y] = ' ';
            else if (d == Direction.Up) arr[x + 1, y] = ' ';
            else if (d == Direction.Left) arr[x, y + 1] = ' ';
            else arr[x, y - 1] = ' ';
            
        }

        public int x, y; public Direction d; public char[,] map;
        public Pacman(int x, int y, char[,] map, Direction d) {
            this.x = x;this.y = y;this.map = map;this.d = d;

            var lines = File.ReadAllLines("map.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
            map[x, y] = '@';
            




        }
    }
}
