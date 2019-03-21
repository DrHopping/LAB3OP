using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB3OP
{


    class Program
    {
        static string mapPath = "Map.txt";
        static int startX;
        static int startY;
        static int finishX;
        static int finishY;
        static bool found = false;

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
                    if (line[j] == 'S') { startX = j; startY = i; }
                    if (line[j] == 'F') { finishX = j; finishY = i; }
                }
            }
            return map;
        }

        static int GetStartDelta(int x, int y)
        {
            return Math.Abs(x - startX) + Math.Abs(y - startY);
        }

        static int GetFinishDelta(int x, int y)
        {
            return Math.Abs(x - finishX) + Math.Abs(y - finishY);
        }

        static int[,] CaclulateDistances(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if(map[i,j] != -1)
                    {
                        map[i, j] = GetFinishDelta(j, i) + GetStartDelta(j, i)*2;
                    }
                }
            }
            return map;
        }
        

        static void Print(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == startX && i == startY)
                        Console.Write("S".PadLeft(2));
                    else
                    if (j == finishX && i == finishY)
                        Console.Write("F".PadLeft(2));
                    else
                    if (map[i, j] == -1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("X".PadLeft(2));
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                        Console.Write(map[i, j].ToString().PadLeft(2));
                }
                Console.WriteLine();
            }
        }

        static bool Walkable(int[,] map, int i, int j)
        {
            if (map[i - 1, j] == map[i, j] - 1 || map[i + 1, j] == map[i, j] - 1 || map[i, j - 1] == map[i, j] - 1 || map[i, j + 1] == map[i, j] - 1)
                return true;
            return false;
        }


        static void TracePath(int[,] map)
        {
            Stack<Tuple<int, int>> steps = new Stack<Tuple<int, int>>();

            int i = finishY;
            int j = finishX;

            while (true)
            {
                if (j == startX && i == startY) break;

                if (map[i - 1, j] == map[i, j] - 1)
                {
                    steps.Push(new Tuple<int, int>(i - 1, j));
                    i = i - 1;
                    continue;
                }

                if (map[i + 1, j] == map[i,j] - 1)
                {
                    steps.Push(new Tuple<int, int>(i + 1, j));
                    i = i + 1;
                    continue;
                }

                if (map[i, j - 1] == map[i,j] - 1)
                {
                    steps.Push(new Tuple<int, int>(i, j - 1));
                    j = j - 1;
                    continue;
                }

                if (map[i, j + 1] == map[i,j] - 1)
                {
                    steps.Push(new Tuple<int, int>(i, j + 1));
                    j = j + 1;
                    continue;
                }

                while(!Walkable(map,i,j))
                {
                    map[i, j] = -2;
                    Console.Clear();
                    Print(map);
                    i = steps.Peek().Item1;
                    j = steps.Peek().Item2;
                    steps.Pop();
                }
            }

            foreach (var step in steps)
            {
                map[steps.Peek().Item1, steps.Peek().Item2] = 0;
            }

        }

        //static void TraceRoute(int[,] map, int i, int j)
        //{
        //    Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        //    stack.Pop(). ;

        //    int tmp = map[i, j];
        //    map[i, j] = 0;

        //    if (map[i - 1, j] == tmp - 1)
        //        TraceRoute(map, i - 1, j);
        //    else
        //        if (map[i + 1, j] == tmp - 1)
        //        TraceRoute(map, i + 1, j);
        //    else
        //        if (map[i, j - 1] == tmp - 1)
        //        TraceRoute(map, i, j - 1);
        //    else
        //        if (map[i, j + 1] == tmp - 1)
        //        TraceRoute(map, i, j + 1);
        //    else
        //        if (i == startY && j == startX)
        //    {
        //        found = true;
        //        return;
        //    }

        //    return;

        //}

        //static int Max(int[,] map)
        //{
        //    int max = map[0, 0];
        //    for (int i = 0; i < map.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(1); j++)
        //        {
        //            if (map[i, j] > max) max = map[i, j];
        //        }
        //    }
        //    return max;
        //}

        static void Main(string[] args)
        {
            var map = LoadMap();
            map = CaclulateDistances(map);
            Print(map);
            TracePath(map);
            Print(map);
            Console.ReadLine();

        }
    }
}
