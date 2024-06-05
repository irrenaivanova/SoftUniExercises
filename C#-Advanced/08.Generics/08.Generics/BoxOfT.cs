using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Generics
{
    public class Box<T>
    {
        private int count;
        private List<T> list;
        public int Count { get { return this.count; } }

        public Box() 
        {
            list = new List<T>();
        }
         public void Add(T item)
        {
           list.Add(item);
            count++;
        }
        public T Remove() 
        {
            T last = list[list.Count - 1];
            list.Remove(last);
            count--;
            return last;
        }
    }
}
