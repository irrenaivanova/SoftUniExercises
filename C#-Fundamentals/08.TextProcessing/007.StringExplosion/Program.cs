using System.Text;
string input = Console.ReadLine();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '>')
    {
        int explosion = (int)input[i + 1] - 48;
        int countSign = 0;
        // da dobavq,ako e samo edin > , gyrmi primerno pri abc>3!!!
        for (int j = i + 1; j < Math.Min((i + explosion + 1), input.Length); j++)
        {
            if (input[j] == '>')
            {
                explosion += 1 + (int)input[j + 1] - 48;
                countSign++;
            }
        }
        if (i + 1 + explosion < input.Length)
            input = input.Remove(i + 1, explosion);
        else
            input = input.Remove(i + 1);


        for (int p = 0; p < countSign; p++)
        {
            input = input.Insert(i + 1, "<");
        }
    }
}

StringBuilder final = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '<')
    {
        final.Append(">");
    }
    else
    {
        final.Append(input[i]);
    }
}
Console.WriteLine(final);