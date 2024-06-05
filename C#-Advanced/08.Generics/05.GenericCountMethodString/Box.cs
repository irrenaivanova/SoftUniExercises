using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GenericBoxOfString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> items;
        public Box() 
        { 
        items = new List<T>();  
        }
        public void Add(T item) 
        { 
        items.Add(item);
        }

        public void Swap (int first, int second)
        {
            ValidateIndex(first);
            ValidateIndex(second);

            T temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        private void ValidateIndex(int index)
        {
            if (index<0 || index>=items.Count)
            {
                throw new IndexOutOfRangeException();   
            }
        }
        public int BiggerValues (T element)
        {
            int count = 0;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].CompareTo(element)==1)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T item in items) 
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().Trim();
        }
    }
}
