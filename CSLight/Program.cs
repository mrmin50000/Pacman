using System;
using System.Threading.Tasks;
using System.Threading;


namespace CSLight
{
    internal class Program
    {

        static void Main(string[] args)
        {

            char[,] map = new char[12,56];
            ConsoleKeyInfo keyinfo;
            Direction d = Direction.Right, d1 = Direction.Down, d2 = Direction.Down;
            int x = 1, y = 2, x1 = 3, y1 = 2, k = 0, x2 = 7, y2 = 34;
            Console.ForegroundColor = ConsoleColor.Blue;
            Pacman p = new Pacman(x, y, map, d);
            Enemy m = new Enemy(x1, y1, map, d1);
            Enemy m1 = new Enemy(x2, y2, map, d2);


            Task.Run(() =>
            {
                while (true)
                {
                    keyinfo = Console.ReadKey();
                }
                
            });            
            


            keyinfo = Console.ReadKey();

            while (true)
            {
                Console.Clear();
                p.drawmap(map);
                p.key(keyinfo);
                Console.Clear();
                m.drawmap(map);
                m.arrow(map, d1, p);
                m1.arrow(map, d2, p);
                
                if ((p.x == m.x && p.y == m.y) || (p.x == m1.x && p.x == m1.y))
                {
                    Console.WriteLine("LOSE!");
                    Console.ReadKey();
                    break;
                }



                Thread.Sleep(500);                              
                
            }

        }
    }
}
