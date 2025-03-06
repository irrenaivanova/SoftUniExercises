using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpPost("count")]
        public IActionResult CountCharacters([FromBody] CountModel input)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (char c in input.InputString)
            {
                if(!dictionary.ContainsKey(c))
                {
                    dictionary[c] = 0;
                }
                dictionary[c]++;
            }
            return Ok(dictionary);
        }

        [HttpPost("count2")]
        public IActionResult CountCharacters2([FromBody] string input)
        {
            var result = input.GroupBy(c => c)
                              .ToDictionary(g => g.Key, g => g.Count());
            return Ok(result);
        }

        [HttpPost("primeNumbers")]
        public IActionResult PrimeNumbers([FromBody] RangePrimeNumbers input)
        {
            List<int> primeNumbers = new List<int>();
            int start = input.Start;
            int end = input.End;
            for (int i = start; i <= end; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }

            return Ok(primeNumbers);

        }

        [HttpPost("longest")]
        public IActionResult LongestSubsequence([FromBody] string input)
        {
            string maxString = string.Empty;
            string currentString = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (!currentString.Contains(input[i]))
                {
                    currentString += input[i];
                    if(currentString.Length > maxString.Length)
                    {
                        maxString = currentString;
                    }
                }
                else
                {
                    currentString = string.Empty;
                }

            }
            return Ok(maxString);
        }

        [HttpPost("longestBest")]
        public IActionResult LongestSubsequenceBest([FromBody] string input)
        {
            HashSet<char> chars = new HashSet<char>();
            int maxLength = 0;
            int start = 0;
            int tempStart = 0;
            for (int i = 0; i < input.Length; i++)
            {
                while (chars.Contains(input[i]))
                {
                    chars.Remove(input[tempStart]);
                    tempStart++;
                }

                chars.Add(input[i]);
                if(i - tempStart + 1 > maxLength)
                {
                    maxLength = i - tempStart + 1;
                    start = tempStart;
                }
            }
            string maxString = input.Substring(start, maxLength);
            return Ok(maxString);
        }
    }
}
