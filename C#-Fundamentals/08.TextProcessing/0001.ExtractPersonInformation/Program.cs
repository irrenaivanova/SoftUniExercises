using System.Security.Cryptography;

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    int startName = input.IndexOf("@");
    int endName = input.IndexOf("|");
    int startAge = input.IndexOf("#");
    int endAge = input.IndexOf("*");
    string name = input.Substring(startName + 1, endName - startName - 1);
    string age = input.Substring(startAge + 1, endAge - startAge - 1);
    Console.WriteLine($"{name} is {age} years old.");
}