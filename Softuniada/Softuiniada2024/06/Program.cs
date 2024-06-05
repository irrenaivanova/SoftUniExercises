string input = Console.ReadLine();
List<string> output = new();
SortedDictionary<string, int> numbers = new(Comparer<string>.Create((x, y) => y.CompareTo(x)));

for (int i = 0; i < input.Length; i++)
{
    if (!numbers.ContainsKey(input[i].ToString()))
    {
        numbers.Add(input[i].ToString(), 0);
    }
    numbers[input[i].ToString()]++;
}


if (numbers.All(x=>x.Value%2!=0))
{
    Console.WriteLine("No palindromic number available.");
    return;
}

string odd = numbers.FirstOrDefault(x => x.Value % 2 != 0).Key;

if (odd != null)
{
    output.Add(odd);
}

Dictionary<string,int> evenNumbers = numbers.Where(x=>x.Value %2==0).ToDictionary(x=>x.Key,x=>x.Value);
SortedDictionary<string, int> sortedEvenNumbers = new SortedDictionary<string, int>(evenNumbers);

foreach (var pair in sortedEvenNumbers)
{
    int pairIndex = pair.Value;
   while(true)
    {
        if (pairIndex == 0)
        {
            break;
        }
        output.Insert(0,pair.Key);
        output.Add(pair.Key);
        pairIndex -= 2;
    }
}

Console.WriteLine(string.Join("",output));