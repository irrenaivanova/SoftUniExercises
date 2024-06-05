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
            List<int> even = new List<int>();
            List<int> odd = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]%2==0)
                    even.Add(list[i]);
                else
                    odd.Add(list[i]);
            }
            even = even.OrderByDescending(x=> x).ToList();
            odd = odd.OrderBy(x=>x).ToList();
            for (int i = 0; i < odd.Count; i++)
            {
                yield return odd[i];
            }
            for (int i = 0; i < even.Count; i++)
            {
                yield return even[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
