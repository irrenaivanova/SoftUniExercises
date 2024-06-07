using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Utils
{
    public static class DateTimeValidator
    {
        private static readonly ISet<string> formats = new HashSet<string>() { "M/dd/yyyy h:mm:ss tt"};
        public static bool Validate(string dateTime)
        {
            foreach (var format in formats)
            {
                if (!DateTime.TryParseExact(dateTime,
                    format, CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime datetime))
                {
                    return false;
                }
            }
            return true;
        }

        public static void AddFormat (string format) => formats.Add(format);
    }
}
