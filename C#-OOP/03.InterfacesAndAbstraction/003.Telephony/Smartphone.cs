using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _003.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {

        public void Browsing(string web)
        {
            Regex pattern = new Regex(@"http:\/\/[A-Za-z]+.(bg|com)");
            if (pattern.Match(web).Success)
            {
                Console.WriteLine($"Browsing: {web}!");
            }
            else
                Console.WriteLine("Invalid URL!");
        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}

