
char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
bool[] used = new bool[input.Length];   
char[] comb = new char[input.Length];
List<string> list = new();
Permutate(0);
void Permutate(int index)
{
    if (index>=comb.Length)
    {
        list.Add(string.Join(",", comb));
        Console.WriteLine(string.Join(" ",comb));
        return;
    }
    for (int i = 0; i < input.Length; i++) 
    {
        if (!used[i])
        {
            comb[index] = input[i];
            used[i] = true;
            Permutate(index + 1);
            used[i] = false;
        }
    }
}
Console.WriteLine();
