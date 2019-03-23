using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB3OP
{

    class Program
    {
        static string mapPath = "Map.txt";
        static Node start;
        static Node finish;

        private static int GetMapWidth()
        {
            return new StreamReader(mapPath).ReadLine().Length;
        }

        static int GetMapHeight()
        {
            using (StreamReader sr = new StreamReader(mapPath))
            {
                int i = 0;
                while (sr.ReadLine() != null) { i++; }
                return i;
            }
        }

        static int[,] LoadMap()
        {
            int[,] map = new int[GetMapHeight(), GetMapWidth()]; 
            StreamReader sr = new StreamReader("Map.txt");
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string line = sr.ReadLine();
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (line[j] == 'X') map[i, j] = -1;
                    if (line[j] == 'S') { start = new Node(j, i); }
                    if (line[j] == 'F') { finish = new Node(j, i); }
                }
            }
            return map;
        }

        static void DrawMap(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == -1)
                        Console.Write("X".PadLeft(2));
                    else if (map[i, j] == 0)
                        Console.Write("  ");
                    else
                        Console.Write(map[i, j].ToString().PadLeft(2));
                }
                Console.WriteLine();
            }
        }
        
        static void DrawColor(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == start.x && i == start.y)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        continue;
                    }

                    if (map[i, j] == -1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        continue;
                    }

                    if (map[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }


                    if (j == finish.x && i == finish.y)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        continue;
                    }


                    if (map[i, j] > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        continue;
                    }

                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var map = LoadMap();
            Console.SetWindowSize(map.GetLength(1)*2 + 1, map.GetLength(0));
            AStarPathfind pathfinding = new AStarPathfind(start, finish, map);

            if (pathfinding.FindPath())
            {
                pathfinding.DrawPath();
                DrawColor(map);
            }
            else
                Console.WriteLine("There is no way from start to finish!");
            Console.ReadLine();

        }
    }
}
