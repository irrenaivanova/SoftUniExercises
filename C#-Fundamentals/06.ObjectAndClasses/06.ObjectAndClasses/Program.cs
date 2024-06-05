using System.Globalization;

string[] input = Console.ReadLine().Split();

for (int i = 0; i < input.Length; i++)
{
    Random random = new Random();
    int randomNumber = random.Next(0, input.Length);
    string temp = input[randomNumber];
    input[randomNumber] = input[i];
    input[i] = temp;
}
Console.WriteLine(string.Join("\n", input));