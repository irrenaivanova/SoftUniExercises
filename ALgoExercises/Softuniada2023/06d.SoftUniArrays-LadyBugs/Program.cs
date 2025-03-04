int n = int.Parse(Console.ReadLine()!);
int[] ints = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int[] game = new int[n];

for (int i = 0; i < ints.Length; i++)
{
    if (ints[i] < 0 || ints[i] > n-1)
    {
        continue;
    }
    game[ints[i]] = 1;
}

while(true)
{
    string input = Console.ReadLine()!;
    if (input == "end")
    {
        break;
    }
    string[] move = input.Split(" ");
    int indexOfBug = int.Parse(move[0]);
    string direction = move[1];
    int length = int.Parse(move[2]);
    
    if (length == 0)
    {
        continue;
    }

    if (indexOfBug < 0 || indexOfBug > n-1 )
    {
        continue;
    }

    if (game[indexOfBug] == 0)
    {
        continue;
    }

    game[indexOfBug] = 0;
    
    if (!IsSafe(indexOfBug, length, direction))
    {
        continue;
    }

    if (IsEmpty(indexOfBug, length, direction))
    {
        PlaceTheBug(indexOfBug, length, direction);
    }
    else
    {
        int count = 2;
        while(true)
        {
            int newLength = length * count;
            if (!IsSafe(indexOfBug, newLength, direction))
            {
                break;
            }

            if (IsEmpty(indexOfBug, newLength, direction))
            {
                PlaceTheBug(indexOfBug, newLength, direction);
                break;
            }
            count++;
        }
    }

}

void PlaceTheBug(int indexOfBug, int length, string direction)
{
    int targetLength = direction == "right" ? indexOfBug+length : indexOfBug - length;
    game[targetLength] = 1;
}

bool IsEmpty(int indexOfBug, int length, string direction)
{
    int targetLength = direction == "right" ? indexOfBug + length : indexOfBug - length;
    return game[targetLength] == 0;
}

bool IsSafe(int indexOfBug, int length, string direction)
{
    int targetLength = direction == "right" ? indexOfBug + length : indexOfBug - length;
    return targetLength < game.Length - 1 && targetLength >= 0; 
}

Console.WriteLine(string.Join(" ",game));