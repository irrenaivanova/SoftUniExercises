using System.Text.RegularExpressions;

List<Food> foods = new();
string input = Console.ReadLine();
string pattern = @"([|#])([A-Za-z\s]+)(\1)(([0-9]{2}\/){2}[0-9]{2})(\1)([[0-9]{1,5})(\1)";

MatchCollection matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
    foods.Add(new Food(match.Groups[2].Value, match.Groups[4].Value, int.Parse(match.Groups[7].Value)));
}

int days = foods.Sum(x => x.Calories)/2000;

Console.WriteLine($"You have food to last you for: {days} days!");
if (foods.Count > 0)
{
    Console.WriteLine(string.Join("\n", foods.Select(x => $"Item: {x.Name}, Best before: {x.Date}, Nutrition: {x.Calories}")));
}

class Food
{
    public Food(string name, string date, int calories)
    {
        Name = name;
        Date = date;
        Calories = calories;
    }

    public string Name { get; set; }
    public string Date { get; set; }

    public int Calories { get; set; }

}
