namespace LAB3OP
{
    class PriorityQueue<T>
    {
        public class Node
        {
            public T data;
            public int priority;
            public Node next;
        }

        private Node back;

        private bool Compare(Node prev, Node next)
        {
            return prev.priority > next.priority;
        }

        public void Enqueue(T value, int valuePriority)
        {
            Node temp = new Node();
            temp.data = value;
            temp.priority = valuePriority;
            temp.next = null;

            if (back == null)
            {
                back = temp;
                return;
            }

            Node p = back, prev = null;
            for (; p != null && Compare(temp, p); prev = p, p = p.next) ;

            if (p == back)
            {
                temp.next = back;
                back = temp;
                return;
            }

            prev.next = temp;
            if (p == null) return;

            temp.next = p;
        }

        public T Dequeue()
        {
            T value;

            if (back == null)
            {
                throw new System.Exception("Queue is empty");
            }

            value = back.data;
            back = back.next;
            return value;
            
        }

        public T Peek()
        {

            if (back == null)
            {
                throw new System.Exception("Queue is empty");
            }

            return back.data;
        }

        public bool IsEmpty => (back == null);

    }
}
