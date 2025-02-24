int[] numbers = Console.ReadLine()!.Split(", ").Select(int.Parse).ToArray();
int sum = int.Parse(Console.ReadLine()!);

List<List<int>> results = new List<List<int>>();
List<int> result= new List<int>();

FindAllNumbers(0, 0);
Console.WriteLine(string.Join("\n", results.Select(x => string.Join(" ", x))));
void FindAllNumbers(int index, int currentSum)
{
    if (currentSum == sum)
    {
        results.Add(new List<int>(result));
        return;
    }

    if (index == numbers.Length)
    {
        return;
    }
    for (int i = index; i < numbers.Length; i++)
    {
        int currentNumber = numbers[i];
        
        currentSum += currentNumber;
        result.Add(currentNumber);
        
        FindAllNumbers(i+1, currentSum);


        currentSum -= currentNumber;
        result.RemoveAt(result.Count-1);
    }
}

