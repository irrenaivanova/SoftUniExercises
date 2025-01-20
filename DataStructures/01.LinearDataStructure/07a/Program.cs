int n = int.Parse(Console.ReadLine());
int[] petrol = new int[n];
int[] distance = new int[n];

for (int i = 0; i < n; i++)
{
    var input = Console.ReadLine().Split();
    petrol[i] = int.Parse(input[0]);
    distance[i] = int.Parse(input[1]);
}

int totalPetrol = 0;   
int currentPetrol = 0;  
int startIndex = 0;      

for (int i = 0; i < n; i++)
{
    totalPetrol += petrol[i] - distance[i];  
    currentPetrol += petrol[i] - distance[i]; 

    if (currentPetrol < 0)
    {
        startIndex = i + 1;
        currentPetrol = 0;
    }
}

if (totalPetrol < 0)
{
    Console.WriteLine(-1);  
}
else
{
    Console.WriteLine(startIndex);  
}