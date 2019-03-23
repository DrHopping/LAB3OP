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
        


        public Node(int x, int y,int heuristic, Node parent )
        {
            this.parent = parent;
            this.x = x;
            this.y = y;
            gCost = parent.gCost + 1;
            hCost = heuristic;
            totalCost = gCost + hCost;
        }

        
    }
}
