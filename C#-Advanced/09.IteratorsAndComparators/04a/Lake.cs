using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Froggy
{
    public class Lake:IEnumerable<int>
    {
        public Lake(List<int> list) 
        { 
            this.list = list;   
        }
        private List<int> list;

        public IEnumerator<int> GetEnumerator()
        {

            for (int i = 0; i < list.Count; i+=2)
            {
                yield return list[i];
            }
            int start = list.Count - 1;
            if (list.Count % 2 == 0)
            {
                start = list.Count - 1;
            }
            else
                start = list.Count - 2;

            for (int i = start; i > 0; i-=2)
            {
                yield return list[i];
            }
   
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
