using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumLinkedList2
{
    public class SoftUniLinkedList
    {
        public int Count { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public void AddFirst(int value)
        {
            Node node = new Node(value);
            if (Head==null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Previous = node;
            Head = node;
            Count++;
        }
        public void AddLast(int value) 
        {
            Node node = new Node(value);
            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public void RemoveFirst() 
        {
            if (Head.Next==null)
            {
                Head = null;
                Tail = null;
            }
            Node old = Head;
            old.Next = null;
            Head = Head.Next;
            Head.Previous = null;
            Count--;
        
        }

        public void RemoveLast()
        {
            if (Tail.Previous == null)
            {
                Head = null;
                Tail = null;
            }
            Node old = Tail;
            old.Previous = null;
            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
        }
        public void ForEach(Action<int> callback)
        {
            Node node = Head;
            while (node != null)
            {
                callback(node.Value);
                node = Head.Next;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[Count];
            int i = 0;
            ForEach(x => array[i++] = x);
            return array;
        }
    }
}
