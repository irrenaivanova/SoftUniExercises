List<int> numbers = new List<int>() { 5, 7, 2, 10, 8, 9 };

var result = InsertionSort(numbers);
Console.WriteLine(string.Join(", ", result));

List<int> InsertionSort(List<int> unsorted)
{
    List<int> numbers = new List<int>(unsorted);

    for (int i = 1; i < numbers.Count; i++)
    {
        int key = numbers[i];

        int j = i - 1;
        while(j >= 0 && key <  numbers[j])
        {
            numbers[j+1] = numbers[j];
            j--;
        }
        numbers[j+1] = key;
    }

    return numbers;
}