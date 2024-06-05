int n = int.Parse(Console.ReadLine());
Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    pumps.Enqueue(new int[] { i, input[0], input[1] });
}
int petrol = 0;
int index = -1;
int count = 0;

while (pumps.Count > 0)
{
    int[] current = pumps.Peek();
    int ifIndex = pumps.Peek()[1] - pumps.Peek()[2];

    if (ifIndex >= 0)
    {
        foreach (var item in pumps)
        {
            petrol += item[1] - item[2];
            if (petrol >= 0)
            {
                count++;
                if (count == n)
                {
                    if (item[0] == n - 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = item[0] + 1;
                    }
                    Console.WriteLine(index);
                    return;
                }
            }
            else
            {
                petrol = 0;
                count = 0;
            }
        }
    }
    else
    {
        pumps.Dequeue();
        pumps.Enqueue(current);
    }
}
