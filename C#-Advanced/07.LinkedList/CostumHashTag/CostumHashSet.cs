using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CostumHashTag
{
    public class CostumHashSet
    {
        private List<string>[] intArray;
        private const int startCount = 8; 
        private int count = 0;
        private int maxCapacity = 95;

        public CostumHashSet() 
        {
            intArray = new List<string>[startCount];
        }

        public void Add(string value) 
        {
            int hash = MakeTheHash(value,intArray.Length);
            if (intArray[hash] == null)
            {
                intArray[hash] = new List<string>();
            }
            intArray[hash].Add(value);
            count++;
            if (1.0 * count / intArray.Length * 100 > maxCapacity)
            {
                Resize();
            }
        }

        private int MakeTheHash(string value,int count)
        {
            int hash = Math.Abs(value.GetHashCode()%count);
            return hash;
        }

        private void Resize()
        {
            List<string>[] newArray = new List<string>[intArray.Length*2];
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] != null)
                {
                    for (int j = 0; j < intArray[i].Count; j++)
                    {
                        int hash = MakeTheHash(intArray[i][j], newArray.Length);

                        if (newArray[hash] == null)
                        {
                            newArray[hash] = new List<string>();
                        }
                        newArray[hash].Add(intArray[i][j]);
                    }
                }
            }
            intArray = newArray;
        }
        public bool Contains(string value)
        {
            int hash = MakeTheHash(value, intArray.Length);
            if (intArray[hash]!=null)
            {
                for (int i = 0; i < intArray[hash].Count; i++)
                {
                    if (intArray[hash][i] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
