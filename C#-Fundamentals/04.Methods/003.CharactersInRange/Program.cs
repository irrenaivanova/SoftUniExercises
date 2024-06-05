char start = char.Parse(Console.ReadLine());
char end = char.Parse(Console.ReadLine());

AllCharactersBetween(start, end);

void AllCharactersBetween(char start, char end)
{
    if (start < end)
        for (int i = Convert.ToInt32(start) + 1; i < Convert.ToInt32(end); i++)
        {
            Console.Write($"{Convert.ToChar(i)} ");
        }
    else
        for (int i = Convert.ToInt32(end) + 1; i < Convert.ToInt32(start); i++)
        {
            Console.Write($"{Convert.ToChar(i)} ");
        }
}