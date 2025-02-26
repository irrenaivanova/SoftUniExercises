List<int> numbers = new List<int>() { 5, 7, 2, 10, 8, 9 };

var result = InsertionSort(numbers);
Console.WriteLine(string.Join(", ", result));

List<int> InsertionSort(List<int> unsorted)
{
    List<int> numbers = new List<int>(unsorted);
    
    for (int i = 1; i < numbers.Count; i++)
    {
        int index = i;
        for (int j = i-1; j >= 0; j--)
        {
            if (numbers[index] < numbers[j])
            {
                (numbers[index], numbers[j]) = (numbers[j], numbers[index]);
                index = j;
            }
            else
            {
                break;
            }
        }
    }

    return numbers;
}