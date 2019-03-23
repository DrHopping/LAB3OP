namespace LAB3OP
{
    class Node
    {
        public int x;
        public int y;
        public int gCost;
        public int hCost;
        public int totalCost;
        public Node parent;

        public Node() { }

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Node(int x, int y,int heuristic, Node parent )
        {
            this.parent = parent;
            this.x = x;
            this.y = y;
            gCost = parent.gCost + 1;
            hCost = heuristic;
            totalCost = gCost + hCost;
        }

        public static bool Compare(Node node1, Node node2)
        {
            return (node1.x == node2.x && node1.y == node2.y);
        }

        
    }
}
