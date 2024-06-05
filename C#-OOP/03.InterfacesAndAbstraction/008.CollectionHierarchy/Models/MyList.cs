using _008.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private readonly List<string> data;

        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        public MyList()
        {
            this.data = new List<string>();
        }

        public int Used => data.Count;

        public int Add(string item)
        {
            data.Insert(AddIndex, item);
            return AddIndex;
        }

        public string Remove()
        {
            string item = null;
            if (data.Count > 0) 
            {
                item = data[RemoveIndex];
                data.Remove(item);
            }
            return item;
        }
    }
}
