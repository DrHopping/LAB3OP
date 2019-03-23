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

        public static bool Compare(Node node1, Node node2)
        {
            return (node1.x == node2.x && node1.y == node2.y);
        }

        
    }
}
