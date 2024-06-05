string[] input = Console.ReadLine().Split(", ");
bool isValid = true;

for (int i = 0; i < input.Length; i++)
{
    isValid = true;
    if (input[i].Length < 3 || input[i].Length > 16)
    {
        isValid = false;
        continue;
    }
    for (int j = 0; j < input[i].Length; j++)
    {
        char c = input[i][j];
        if (!(Char.IsLetter(c) || Char.IsDigit(c) || c == '_' || c == '-'))
        {
            isValid = false;
            break;
        }
    }
    if (isValid)
    {
        Console.WriteLine(input[i]);
    }
}