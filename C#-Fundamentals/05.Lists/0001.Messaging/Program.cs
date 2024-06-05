List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
string text = Console.ReadLine();
string final = string.Empty;

for (int i = 0; i < numbers.Count; i++)
{
    int n = numbers[i];
    int sum = 0;
    int place = 0;
    while (n > 0)
    {
        sum += n % 10;
        n /= 10;
    }
    place = sum % text.Length;
    final += text[place];
    text = text.Remove(place, 1);
}
Console.WriteLine(final);