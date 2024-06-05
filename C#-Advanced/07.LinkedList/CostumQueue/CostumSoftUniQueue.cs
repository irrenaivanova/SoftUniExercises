using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumQueue
{
    public class CostumSoftUniQueue
    {
        private const int initCap = 4;
        private const int firstEl = 0;
        private int?[] items;
        public int Count { get; private set; }
        public CostumSoftUniQueue()
        {
           items = new int?[initCap];
        }

        public void Enqueue(int element)
        {
            items[Count]=element;
            Count++;
            if (Count == initCap) 
            {
                Resize();
            }
        }
        public int? Dequeue()
        {
            if (Count == 0) 
            {
                throw new InvalidOperationException("The stack is empty");
            }

            int? removedEl = items[firstEl];
            items[firstEl] = default;
            ShiftDown();
            Count--;
            return removedEl;
        }
        public void ForEach(Action<int?> action) 
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(items[i]+ " ");
            }
        }
        public int? Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            int? removedEl = items[firstEl];
            ;
            return removedEl;
        }
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = null;
            }
            Count = 0;
        }

        private void ShiftDown()
        {
            int?[] newArray = new int?[items.Length];
            for (int i = 0; i < Count-1; i++)
            {
                newArray[i] = items[i+1];
            }
            items = newArray;
        }

        private void Resize()
        {
            int?[] newArray = new int? [items.Length*2];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;   
        }
    }
}
