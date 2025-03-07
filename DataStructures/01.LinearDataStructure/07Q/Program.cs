﻿int n = int.Parse(Console.ReadLine());
Queue<int[]> truckTour = new Queue<int[]>();

for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    int petrol = input[0];
    int distance = input[1];

    truckTour.Enqueue(input);
}
int startIndex = 0;

while (true)
{
    int currentPetrol = 0;
    foreach (var info in truckTour)
    {
        int truckPetrol = info[0];
        int truckDistance = info[1];

        currentPetrol += truckPetrol;
        currentPetrol -= truckDistance;
        startIndex++;

        if (currentPetrol < 0)
        {
            int[] element = truckTour.Dequeue();
            truckTour.Enqueue(element);
            break;
        }
    }
    if (currentPetrol >= 0)
    {
        Console.WriteLine(startIndex);
        break;
    }
}
