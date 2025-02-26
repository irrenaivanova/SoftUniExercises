List<int> numbers = new List<int>() { 5, 7, 2, 10, 8, 9 };

var result = SelectionSort(numbers);
Console.WriteLine(string.Join(", ", result));

List<int> SelectionSort(List<int> unsorted)
{
    List<int> numbers = new List<int>(unsorted);

    for (int i = 0; i < numbers.Count; i++)
    {
        int minIndex = i;

        for (int j = i+1; j < numbers.Count; j++)
        {
            if (numbers[j] < numbers[minIndex])
            {
                minIndex = j;
            }
        }
        
        if (minIndex != i)
        {
            (numbers[minIndex],numbers[i]) = (numbers[i], numbers[minIndex]);
        }
    }

    return numbers;
}