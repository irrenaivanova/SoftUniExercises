using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Tuple
{
    public class MyTuple<T,V>
    {
        public T Item1 { get; private set; }
        public V Item2 { get; private set; }

        public MyTuple(T item1, V item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public override string ToString() => $"{Item1} -> {Item2}";
       
    }
}
