float sum = float.Parse(Console.ReadLine());
int[] drumsInit = Console.ReadLine().Split().Select(int.Parse).ToArray();
List<int> drums = new List<int>();
drums.AddRange(drumsInit);

while (true)
{
    string command = Console.ReadLine();
    if (command == "Hit it again, Gabsy!")
        break;

    int power = int.Parse(command);


    for (int i = 0; i < drums.Count; i++)
    {
        if (power < drums[i] && drums[i] != 0)
        {
            drums[i] -= power;
        }
        else if (power >= drums[i] && drums[i] != 0)
        {
            int priceNew = 3 * drumsInit[i];
            if (sum >= priceNew)
            {
                drums[i] = drumsInit[i];
                sum -= priceNew;
            }
            else
            { drums[i] = 0; }
        }
    }
}


for (int i = 0; i < drums.Count; i++)
{
    if (drums[i] > 0)
        Console.Write($"{drums[i]} ");
}
Console.WriteLine();
Console.WriteLine($"Gabsy has {sum:f2}lv.");