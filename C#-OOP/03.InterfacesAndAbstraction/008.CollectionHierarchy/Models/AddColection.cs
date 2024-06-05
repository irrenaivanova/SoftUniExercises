using _008.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.CollectionHierarchy.Models
{
    public class AddColection : IAdd
    {
        private readonly List<string> data;

        public AddColection()
        {
            data = new List<string>();
        }

     
        public int Add(string item)
        {
            data.Add(item);
            return data.Count-1;
        }
    }
}
