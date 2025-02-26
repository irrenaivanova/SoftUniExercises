List<int> numbers = new List<int>() { 5,7,2,10,8,9 };

var result = BubbleSort(numbers);
Console.WriteLine(string.Join(", ", result));

List<int> BubbleSort(List<int> numbers)
{
    List<int> sorted = new List<int>(numbers);
    int n = numbers.Count;
    bool swapped;
    
    for (int j = 0; j < n - 1; j++)
    {
        swapped = false;

        for (int i = 0; i < n - 1 - j; i++)
        {
            int current = sorted[i];
            int next = sorted[i + 1];
            if (current > next)
            {
                int temp = sorted[i];
                sorted[i] = sorted[i+1];
                sorted[i+1] = temp;
                swapped = true;
            }
        }

        if (!swapped)
        {
            break;
        }
    }

    return sorted;
}