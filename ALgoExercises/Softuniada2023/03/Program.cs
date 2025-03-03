string input = Console.ReadLine()!;
int longest = 0;
int current = 0;
bool open = false;

for (int i = 0; i<input.Length; i++)
{
    if (input[i] == '(')
    {
        if (open)
        {
            if (current > longest)
            {
                longest = current;
            }
            current = 0;
        }
        else
        {
            open = true;
        }

    }
    if (input[i] == ')')
    {
        if (open)
        {
            current += 2;
            open = false;
        }
        else
        {
            if (current > longest)
            {
                longest = current;
            }
            current = 0;  
        }
    }
}
if (longest == 0)
{
    longest = current;
}
if (current > longest)
{
    longest = current;
}
Console.WriteLine(longest);
