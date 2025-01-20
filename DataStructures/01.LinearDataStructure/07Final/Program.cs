int n = int.Parse(Console.ReadLine());
int[] oil = new int[n];
int[] distance = new int[n];

// Reading input
for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    oil[i] = input[0];
    distance[i] = input[1];
}

int totalPetrol = 0;  // Track overall petrol balance
int currentPetrol = 0;  // Track petrol balance for the current starting point
int startIndex = 0;  // The current starting pump index

// Iterate over all petrol pumps
for (int i = 0; i < n; i++)
{
    int balance = oil[i] - distance[i];
    totalPetrol += balance;  // Add to total petrol balance
    currentPetrol += balance;  // Add to the current journey balance

    // If the current balance drops below 0, reset the startIndex
    if (currentPetrol < 0)
    {
        startIndex = i + 1;  // Move the starting point to the next pump
        currentPetrol = 0;  // Reset the current journey balance
    }
}

// If total petrol is negative, completing the circuit is impossible
if (totalPetrol < 0)
{
    Console.WriteLine(-1);
}
else
{
    Console.WriteLine(startIndex);
}
