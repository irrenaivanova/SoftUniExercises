
Dictionary<int, List<char>> digits = new Dictionary<int, List<char>>()
{
    {2, new List<char>(){'A','B','C' } },
    {3, new List<char>(){'D','E','F' } },
    {4, new List<char>(){'G','H','I' } },
};

int[] numbers = Console.ReadLine()!.Select(x => x - '0').ToArray();

List<char[]> results = new List<char[]>();
char[] result = new char[numbers.Length];

int[] startsOfChars = new int[numbers.Length];
FindAll(0);

Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ", x))));

void FindAll(int index)
{
    if (index == numbers.Length)
    {
        results.Add(result.ToArray());
        return;
    }

    List<char> chars = digits[numbers[index]];
    for (int i = 0; i < chars.Count; i++)
    {
        result[index] = chars[i];
        FindAll(index+1); 
    }
}

