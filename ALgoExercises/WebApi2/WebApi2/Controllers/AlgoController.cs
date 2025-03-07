using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgoController : ControllerBase
    {
        [HttpPost("AllSubSetSum")]
        public IActionResult AllSubSetSums([FromBody] int[] numbers)
        {
            HashSet<int> allSums = new HashSet<int>();
            allSums.Add(numbers[0]);

            for (int i = 1; i < numbers.Length; i++)
            {
                HashSet<int> newSums = new HashSet<int>();
                                    newSums.Add(numbers[i]);
                foreach (int sum in allSums)
                {
                    newSums.Add(numbers[i] + sum);

                }
                allSums.UnionWith(newSums);
            }

            return Ok(allSums);
        }

        [HttpPost("DividingPresents")]
        public IActionResult DividingPresents([FromBody] int[] numbers)
        {
            HashSet<int> allSums = new HashSet<int>();
            int totalSum = numbers.Sum();
            List<int>[] array = new List<int>[totalSum+1];
            
            allSums.Add(numbers[0]);
            array[numbers[0]] = new List<int>() {-1};

            for (int i = 1; i < numbers.Count(); i++)
            {
                HashSet<int> newSums = new HashSet<int>();
                newSums.Add(numbers[i]);
                array[numbers[i]] = new List<int>() { -1 };
                foreach (int sum in allSums)
                {
                    int newSum = numbers[i] + sum;
                    newSums.Add(newSum);
                    if (array[newSum] == null)
                    {
                        array[newSum] = new List<int>();
                    }
                    array[newSum].Add(sum);
                }
                newSums.Add(numbers[i]);
                allSums.UnionWith(newSums);
            }

            int AlanSum = 0;

            for (int i = array.Length/2; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    continue;
                }

                AlanSum = i;
                break;
            }

            
            List<int> gifts = new List<int>();
            int bobSum = totalSum - AlanSum;
            int currentSum = bobSum;
            while (bobSum > 0)
            {
                int previousSum = array[currentSum][0];
                gifts.Add(currentSum - previousSum);
                currentSum = previousSum;
            }
    

            var output = new OutputSums(AlanSum,bobSum,gifts);
            return Ok(output);
        }

        [HttpPost("AllSubSetEqualNumber")]
        public IActionResult AllSubSetSums([FromBody] InputModelNumber input)
        {
            HashSet<int> allSums = new HashSet<int>();
            allSums.Add(input.Numbers[0]);

            for (int i = 1; i < input.Numbers.Count(); i++)
            {
                HashSet<int> newSums = new HashSet<int>();
                foreach (int sum in allSums)
                {
                    newSums.Add(input.Numbers[i] + sum);
                    newSums.Add(input.Numbers[i]);
                }
                allSums.UnionWith(newSums);
                if (allSums.Contains(input.Sum))
                {
                    return Ok(true);
                }
            }

            return Ok(false);
        }
    }
}
