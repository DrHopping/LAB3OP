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

            if (back.next == null)
            {
                value = back.data;
                back = null;
                return value;
            }

            Node prev, end;
            prev = end = back;
            while (end.next != null)
            {
                prev = end;
                end = end.next;
            }

            value = end.data;
            prev.next = null;
            return value;
        }

        public T Peek()
        {
            if (back != null)
                return back.data;
            else
                throw new System.Exception("Queue is empty");
        }

        public int PeekPriority()
        {
            Node cursor = back;
            while (cursor.next != null)
                cursor = cursor.next;
            return cursor.priority;
        }

        public void Clear()
        {
            while (back != null)
                back = back.next;
        }

        public bool IsEmpty()
        {
            return (back == null);
        }

        public int Size()
        {
            int size = 0;
            Node cursor = back;
            while (cursor != null)
            {
                size++;
                cursor = cursor.next;
            }
            return size;
        }
    }
}
