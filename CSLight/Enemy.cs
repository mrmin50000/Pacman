using System.IO;


namespace CSLight
{
    class Enemy : Pacman
    {
        public void arrow(char[,] map, Direction d, Pacman p)
        {
            if (x < p.x && map[x + 1, y] != '#')
            {
                d = Direction.Down;
                x += 1;
                this.move(x, y, map, d);
            }
            else if (x > p.x && map[x - 1, y] != '#')
            {
                
                d = Direction.Up;
                x -= 1;
                this.move(x, y, map, d);
               
            }
            else if (y > p.y && map[x, y - 1] != '#')
            {
                
                d = Direction.Left;
                y -= 1;
                this.move(x, y, map, d);
                
            }
            else if (y < p.y && map[x, y + 1] != '#')
            {
                
                d = Direction.Right;
                y += 1;
                this.move(x, y, map, d);
                
            }


        }
        

        override public void move(int x, int y, char[,] arr, Direction d)
        {
            char t = arr[x, y];
            arr[x, y] = 'Q';
            if (d == Direction.Down) arr[x - 1, y] = t;
            else if (d == Direction.Up) arr[x + 1, y] = t;
            else if (d == Direction.Right) arr[x, y - 1] = t;
            else arr[x, y + 1] = t;
            

        }

        public int x, y; public Direction d; public char[,] map;
        public Enemy(int x, int y, char[,] map, Direction d): base(x, y, map, d)
        {
            this.x = x; this.y = y; this.map = map; this.d = d;
            var lines = File.ReadAllLines("map.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
            map[x, y] = 'Q';
        }
    }
}