int n = int.Parse(Console.ReadLine());
int[][] matrix = new int[n][];

for (int i = 0; i < n; i++)
{
    matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
}

while (true)
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "END")
        break;

    int row = int.Parse(command[1]);
    int col = int.Parse(command[2]);
    int val = int.Parse(command[3]);

    if (row < 0 || row > matrix.Length - 1 || col < 0 || col > matrix[row].Length)
    {
        Console.WriteLine("Invalid coordinates");
        continue;
    }

    if (command[0] == "Add")
    {
        matrix[row][col] += val;
    }
    else if (command[0] == "Subtract")
    {
        matrix[row][col] -= val;
    }
}
foreach (var item in matrix)
{
    Console.WriteLine(string.Join(" ", item));
}