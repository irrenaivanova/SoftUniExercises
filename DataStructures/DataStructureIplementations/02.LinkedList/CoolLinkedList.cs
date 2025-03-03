namespace _02.LinkedList
{
    public class CoolLinkedList<T>
    {
        public class Node
        {
            public T Value;
            public Node? Next;
            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? head;
        private Node? tail;
        private int count;

        public CoolLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count => this.count;

        public void Add(T value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public void AddFirst(T value)
        {
            var newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        public void RemoveFirst()
        {
            var oldHead = this.head;
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            
            if (head.Next == null)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            if(head.Next == null)
            {
                head.Next = null;
                count--;
                return; 
            }

            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            current.Next = null;
            tail = current;
            count--;
        }
    }
}
