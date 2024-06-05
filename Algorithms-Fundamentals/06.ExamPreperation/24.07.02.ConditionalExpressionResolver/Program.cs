using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([tf]) [?] ([\d]+) [:] ([\d]+)";
            string result = string.Empty;
          
            while (true)
            {
                Match match = Regex.Match(input, pattern);
                if (!match.Success)
                {
                    break;
                }
                
                if (match.Groups[1].Value=="t")
                {
                    result = match.Groups[2].Value;
                }
                else
                {
                    result = match.Groups[3].Value;
                }
                input = input.Replace(match.ToString(), result);
            }

            Console.WriteLine(result);
        }
    }
}