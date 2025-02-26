List<int> numbers = new List<int>() { 2, 5, 7, 9, 12, 14 };
int number = 5;

Console.WriteLine(IndexOfTheNumber(numbers,number,0, numbers.Count()));


int IndexOfTheNumber(List<int> numbers, int number, int start, int end)
{
    int mid = (start+end) / 2;
    int midNumber = numbers[mid];
    
    if(start>end)
    {
        return -1;
    }

    if (number == midNumber)
    {
        return mid;
    }
    else if (number < midNumber)
    {
        return IndexOfTheNumber(numbers, number, start, mid-1);
    }
    else
    {
        return IndexOfTheNumber(numbers, number, mid + 1,end);
    }
}
