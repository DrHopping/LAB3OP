using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB3OP
{

    class AStarPathfind
    {
        Node start;
        Node finish;
        int[,] map;

        PriorityQueue<Node> openList = new PriorityQueue<Node>();
        List<Node> closedList = new List<Node>();


        public AStarPathfind(Node start, Node finish, int[,] map)
        {
            this.start = start;
            this.finish = finish;
            this.map = map;
            start.gCost = 0;
            start.hCost = CalcHeuristic(start);
            start.totalCost = start.gCost + start.hCost;
        }

        private int CalcHeuristic(Node location)
        {
            return Math.Abs(finish.x - location.x) + Math.Abs(finish.y - location.y);
        }
        
        public FindPath()
        {
            openList.Enqueue(start, start.totalCost);
            while(!openList.IsEmpty)
            {

            }

        }

    }

    class Program
    {
        static string mapPath = "Map.txt";
        static Node start;
        static Node finish;

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
                    if (line[j] == 'S') { start = new Node(j, i); }
                    if (line[j] == 'F') { finish = new Node(j, i); }
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
