﻿using _008.CollectionHierarchy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemove
    {
        private const int AddIndex = 0; 
        private readonly List<string> data;

        public AddRemoveCollection()
        {
            data = new List<string>();
        }

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
                item = data[data.Count - 1];
                data.Remove(item);
               
            }
            return item;
        }
    }
}
