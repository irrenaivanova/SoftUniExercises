using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumListNamespace
{
    public class CostumList2
    {
        private const int inCap = 2;
        private int[] items;
        public int Count { get;private set; }
        public CostumList2()
        {
            items = new int[inCap];
        }

        public void Add(int value) 
        { 
            if (items.Length == Count) 
            {
                Resize();    
            }
            items[Count] = value;
            Count++;
        }

        public int MyProperty { get; set; }
        public int this[int index]
        {    
            get
            {
                ValidateIndex(index);
                 return items[index]; 
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            } 
        }

        private void Resize()
        {
            int[] newArray = new int[items.Length*2];
            for (int i = 0; i < items.Length; i++) 
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }

        public int RemoveAt(int index)
        {
            int value = items[index];
            ValidateIndex(index);
            ShiftLeft(index);
           
            Count--;
            if (1.0*Count/items.Length<=0.25)
            {
                Shrink();
            }
            return value;
        }
        public void Insert(int index, int value)
        {
            ValidateIndex(index);
            if (items.Length == Count)
            {
                Resize();
            }
            ShiftRight(index);
            items[index] = value;
            Count++;  
        }
        public void AddRange(int[] ints)
        {
            foreach (int item in ints)
            {
                Add(item);
            }
        }

        public bool Contains(int item) 
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i]==item)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int first, int second)
        {
            ValidateIndex(first);
            ValidateIndex(second);
            int temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i-1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] newArray = new int[items.Length/2];
            for (int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
