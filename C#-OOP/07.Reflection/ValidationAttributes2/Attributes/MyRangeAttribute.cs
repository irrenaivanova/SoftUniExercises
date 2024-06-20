using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes2.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public override bool IsValid(object obj)
        => (int)obj >MinValue && (int)obj < MaxValue;
            
    }
}
