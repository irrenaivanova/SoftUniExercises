using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumStack
{
    public class CostumSoftUniStack
    {
        private const int initCap = 4;

        private int[] items;
        public CostumSoftUniStack()
        {
            items = new int[initCap];
        }

        public int Count { get; private set; }

     
        public void Push(int element)
        {
            items[Count] = element;
            Count++;
            if (Count == initCap) 
            {
                Resize();
            }
        }

        public int Peek() 
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return items[Count - 1];
        }
        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
           
            items[Count- 1] = 0;
            Count--;
            return items[Count - 1];
        }

        public void ForEach(Action<int> action) 
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            int[] newArray = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }
    }
}
