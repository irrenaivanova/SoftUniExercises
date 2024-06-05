using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumLinkedList
{
    public class Node<T>
    {
        public Node(T value, Node<T> previous = null, Node<T> next=null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public T Value { get; set; }

        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public override string ToString()
        {
            return $"{Previous.Value} <- {Value} -> {Next.Value}";
        }

    }
}
