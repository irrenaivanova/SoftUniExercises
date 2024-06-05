string[] input = Console.ReadLine().Split();
string finalWord = string.Empty;

for (int i = 0; i < input.Length; i++)
{
    for (int j = 0; j < input[i].Length; j++)
    {
        finalWord += input[i];
    }
}
Console.WriteLine(finalWord);