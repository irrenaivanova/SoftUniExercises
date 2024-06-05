char[] elements = Console.ReadLine().Split().Select(char.Parse).ToArray();

int n = int.Parse(Console.ReadLine());
bool[] used = new bool[elements.Length];
char[] comb = new char[n];

PrintTheComb(0);

void PrintTheComb(int start)
{
    if(start>=n)
    {
        Console.WriteLine(string.Join(" ",comb));
        return;
    }
    for (int i = 0; i < elements.Length; i++)
    {
        if (!used[i])
        {
            comb[start] = elements[i];
            used[i] = true;
            PrintTheComb(start+1);
            used[i] = false;
        }
    }
}