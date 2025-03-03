using System.Text;

List<string> numbers = Console.ReadLine()!.Split().ToList();
numbers = numbers.OrderBy(x => x, Comparer<string>.Create((a,b)=>(b+a).CompareTo(a+b))).ToList();

StringBuilder sb = new StringBuilder();
foreach (var number in numbers)
{
    sb.Append(number);
}
Console.WriteLine(sb.ToString().Trim());