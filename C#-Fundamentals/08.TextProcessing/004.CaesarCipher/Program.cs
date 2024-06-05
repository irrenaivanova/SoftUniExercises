using System.Text;

string input = Console.ReadLine();
StringBuilder encrypted = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    encrypted.Append((char)((int)input[i] + 3));
}
Console.WriteLine(encrypted);
