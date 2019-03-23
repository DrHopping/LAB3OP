using System;
using System.Collections.Generic;

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

        private List<Node> Successors(Node location)
        {
            List<Node> successors = new List<Node>();

            if (location.x - 1 > 0 && map[location.y, location.x - 1] != -1)
                successors.Add(new Node(location.x - 1, location.y));

            if (location.x + 1 < map.GetLength(1) && map[location.y, location.x + 1] != -1)
                successors.Add(new Node(location.x + 1, location.y));

            if (location.y - 1 > 0 && map[location.y - 1, location.x] != -1)
                successors.Add(new Node(location.x, location.y - 1));

            if (location.y + 1 < map.GetLength(0) && map[location.y + 1, location.x] != -1)
                successors.Add(new Node(location.x, location.y + 1));

            return successors;
        }

        private bool InClosedList(Node location)
        {
            foreach (var closed in closedList)
            {
                if (location.x == closed.x && location.y == closed.y)
                    return true;
            }
            return false;
        }

        public bool FindPath()
        {
            openList.Enqueue(start, start.totalCost);
            while(!openList.IsEmpty)
            {
                Node current = openList.Peek();

                if (Node.Compare(finish, current))
                    return true;

                openList.Dequeue();
                closedList.Add(current);

                foreach (var location in Successors(current))
                {
                    //location.gCost = current.gCost + 1;
                    //location.hCost = CalcHeuristic(location);
                    //location.totalCost = location.gCost + location.hCost;
                    int tentativeCost = current.gCost + 1;

                    if (InClosedList(location) && tentativeCost >= location.gCost)

                        continue;
                    if(!InClosedList(location) || tentativeCost < location.gCost)
                    {
                        location.parent = current;
                        location.gCost = tentativeCost;
                        location.hCost = CalcHeuristic(location);
                        location.totalCost = location.gCost + location.hCost;
                        if (!InClosedList(location))
                            openList.Enqueue(location, location.totalCost);
                    }
                }
            }

            return false;
        }

        public void DrawPath()
        {
            Node current = openList.Peek();
            int i = 1;
            while(current != start)
            {
                map[current.y, current.x] = i;
                current = current.parent;
                i++;
            }
        }

    }
}
