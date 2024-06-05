using System.Text;

string input = Console.ReadLine();
StringBuilder digits = new StringBuilder();
StringBuilder letters = new StringBuilder();
StringBuilder characters = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    char c = input[i];
    if (Char.IsDigit(c))
    { digits.Append(input[i]); }
    else if (Char.IsLetter(c))
    { letters.Append(input[i]); }
    else
        characters.Append(c);
}
Console.WriteLine(digits);
Console.WriteLine(letters);
Console.WriteLine(characters);