using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumLinkedList
{
    public class SoftUniLinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T value)
        {
            Count++;
            Node<T> node = new Node<T>(value);
            
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
        
        public void AddLast(T value) 
        { 
            Count++;
            Node<T> node = new Node<T>(value);
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
           Node<T> oldhead = Head;
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

            Node<T> oldtail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            oldtail.Previous = null;
            Count--;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> current = Head;
            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public void ForEachReversed(Action<T> action)
        {
            Node<T> current = Tail;
            while (current != null)
            {
                action(current.Value);
                current = current.Previous;
            }
        }


        public T[] ToArray()
        {
            T[] array = new T[Count];
            int i =0;
            ForEach(x => array[i++] = x);
            return array;
        }
    }
}
