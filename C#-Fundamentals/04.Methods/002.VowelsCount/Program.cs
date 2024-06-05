string input = Console.ReadLine();
Console.WriteLine(NumbersOfVowels(input));

int NumbersOfVowels(string input)
{
    int count = 0;
    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == 'a' || input[i] == 'A' || input[i] == 'e' || input[i] == 'E' || input[i] == 'o' || input[i] == 'O' || input[i] == 'i' || input[i] == 'I' || input[i] == 'u' || input[i] == 'U')
            count++;
    }
    return count;
}