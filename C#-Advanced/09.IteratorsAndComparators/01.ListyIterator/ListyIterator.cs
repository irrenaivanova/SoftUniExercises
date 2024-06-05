using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(params T[] input) 
        {
            items = new List<T>(input);
        }
        private List<T> items;
        private int index =0;

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext() => index < items.Count - 1;
       
        public void Print()
        {
            if (items.Any())
            {
                Console.WriteLine(items[index]);
            }
            else
                throw new InvalidOperationException("Invalid Operation!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }
        public void PrintAll()
        {
            if (!items.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(string.Join(" ",items));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
