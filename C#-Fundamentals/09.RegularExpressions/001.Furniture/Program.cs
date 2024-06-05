using System.Text.RegularExpressions;
double totalSum = 0;
List<string> furnitures = new List<string>();
while (true)
{
    string input = Console.ReadLine();
    if (input == "Purchase")
        break;

    Regex regex = new Regex(@"^>>(?<furniture>[A-Z]*([a-z]+)?)<<(?<price>\d+.?\d+)!(?<quan>[0-9]+)");
    MatchCollection matches = regex.Matches(input);


    foreach (Match match in matches)
    {
        totalSum += float.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quan"].Value);
        string mebel = match.Groups["furniture"].Value;
        furnitures.Add(mebel);
    }
}
Console.WriteLine("Bought furniture:");
foreach (var item in furnitures)
{
    Console.WriteLine(item);
}
Console.WriteLine($"Total money spend: {totalSum:f2}");