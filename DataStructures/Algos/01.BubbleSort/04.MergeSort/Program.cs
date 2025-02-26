
List<int> numbers = new List<int>() { 5, 7, 2, 10, 8, 9, 17, 25, 37, 27 };

var result = MergeSort(numbers);

Console.WriteLine(string.Join(", ", result));

List<int> MergeSort(List<int> numbers)
{
    if (numbers.Count <= 1)
    {
        return numbers;
    }

    int mid = numbers.Count / 2;
    List<int> left = MergeSort(numbers.GetRange(0, mid));
    List<int> right = MergeSort(numbers.GetRange(mid, numbers.Count - mid));

    return Merging(left, right);
}

List<int> Merging(List<int> left, List<int> right)
{
    List<int> result = new List<int>();
    int i = 0;
    int j = 0;
    while(i<left.Count && j<right.Count)
    {
        if (left[i] < right[j])
        {
            result.Add(left[i++]);
        }
        else
        {
            result.Add(right[j++]);
        }
    }

    result.AddRange(left.GetRange(i,left.Count-i));
    result.AddRange(right.GetRange(j, right.Count - j));

    return result;
}