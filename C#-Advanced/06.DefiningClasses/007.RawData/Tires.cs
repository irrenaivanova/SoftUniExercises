using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007.RawData
{
    public class Tires
    {
        public Tires(int age, float tirePress) 
        {
            Age = age;
            TirePress = tirePress;
        }
        public int Age { get; set; }
        public float TirePress { get; set; }
    }
}
