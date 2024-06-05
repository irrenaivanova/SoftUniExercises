using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005.DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceInDays(string start, string end)
        {
   
        DateTime startTime = DateTime.Parse(start);
        DateTime endTime = DateTime.Parse(end);
        TimeSpan days = endTime.Date - startTime.Date;
            int daysD = days.Days;
            return Math.Abs(daysD);
        }
    }
}
