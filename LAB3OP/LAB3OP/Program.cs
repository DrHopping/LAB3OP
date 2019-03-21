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

        

        static void Main(string[] args)
        {
            var map = LoadMap();
            Console.ReadLine();

        }
    }
}
