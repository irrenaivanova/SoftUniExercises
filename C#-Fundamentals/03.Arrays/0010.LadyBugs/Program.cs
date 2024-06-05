int n = int.Parse(Console.ReadLine());
int[] bugsPlaces = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] bugs = new int[n];

for (int i = 0; i < bugsPlaces.Length; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (bugsPlaces[i] == j)
            bugs[j] = 1;
    }
}

while (true)
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "end")
        break;
    int startPos = int.Parse(command[0]);
    int move = int.Parse(command[2]);
    string direction = command[1];

    if (startPos < 0 || startPos > bugs.Length - 1)
        continue;

    if (bugs[startPos] == 0)
        continue;

    bugs[startPos] = 0;

    if (direction == "right")
    {
        int count = 1;
        while (true)
        {
            if (startPos + count * move < bugs.Length
                && bugs[startPos + count * move] == 1)
            {
                count++;
                continue;
            }
            else if (startPos + count * move > bugs.Length - 1)
            {
                break;
            }
            else
            {
                bugs[startPos + count * move] = 1;
                break;
            }
        }
    }
    if (direction == "left")
    {
        int count = 1;
        while (true)
        {
            if (startPos - count * move > 0
                && bugs[startPos - count * move] == 1)
            {
                count++;
                continue;
            }
            else if (startPos - count * move < 0)
            {
                break;
            }
            else
            {
                bugs[startPos - count * move] = 1;
                break;
            }
        }
    }
}
Console.WriteLine(string.Join(" ", bugs));