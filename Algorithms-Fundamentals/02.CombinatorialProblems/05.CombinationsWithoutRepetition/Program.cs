char[] elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
int n = int.Parse(Console.ReadLine());
char[] perm = new char[n];

Permutate(0,0);

void Permutate(int start,int elem)
{
	if (start == n)
	{
		Console.WriteLine(string.Join(" ",perm));
		return;
	}
    for (int i = elem; i < elements.Length; i++)
	{
		perm[start] = elements[i];
		Permutate(start + 1, i + 1);
	}
}