using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Stack
{
    public class CostumStack:IEnumerable<int>
    {
        public List<int> List = new ();
        public int index { get; private set; }
        public IEnumerator<int> GetEnumerator() 
        {
            return new CostumNuumerator(List,List.Count);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public void Push(List<int> list)
        {
            List.AddRange(list);
            index += list.Count;
        }

        public void Pop()
        {
            if (!List.Any())
            {
                throw new InvalidOperationException("No elements");
            }
            List.RemoveAt(index-1);
            index--;
        }
    }

    public class CostumNuumerator : IEnumerator<int>
    {
        public CostumNuumerator(List<int> list, int count)
        {
            this.list = list;
            index = count;
        }
        private List<int> list;

        public int index { get; private set; }

        public int Current => list[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index--;
            if (index < 0)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
        }
    }
}
