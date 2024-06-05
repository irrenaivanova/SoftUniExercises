string input = Console.ReadLine();

while (input != "END")
{
    string reversed = string.Empty;
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reversed += input[i];
    }

    if (reversed == input)
        Console.WriteLine("true");
    else
        Console.WriteLine("false");

    input = Console.ReadLine();
}