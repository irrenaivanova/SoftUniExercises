using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumLinkedList2
{
    public class Node
    {
        public Node(int value, Node previous = null, Node next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public int Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }
    }
}
