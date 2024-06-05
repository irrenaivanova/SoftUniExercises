using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumLinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(int value)
        {
            Count++;
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
        }
        
        public void AddLast(int value) 
        { 
            Count++;
            Node node = new Node(value);
            if (Tail==null) 
            {
                Tail = node;
                Head = node;
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
           Node oldhead = Head;
           Head = Head.Next;
           Head.Previous = null;
           oldhead.Next = null;
           Count--;
        }

        public void RemoveLast()
        {
            if (Tail.Previous==null)
            {
                Tail = null;
                Head = null;
            }

            Node oldtail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            oldtail.Previous = null;
            Count--;
        }

        public void ForEach(Action<int> action)
        {
            Node current = Head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public void ForEachReversed(Action<int> action)
        {
            Node current = Tail;
            while (current != null)
            {
                action(current.Value);
                current = current.Previous;
            }
        }


        public int[] ToArray()
        {
            int[] array = new int[Count];
            int i =0;
            ForEach(x => array[i++] = x);
            return array;
        }
    }
}
