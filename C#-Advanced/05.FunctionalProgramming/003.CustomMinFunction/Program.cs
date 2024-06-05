int[] numbers= Console.ReadLine().Split().Select(int.Parse).ToArray();

Func<int[], int> theSmallest = x => x.Min();

Console.WriteLine(theSmallest(numbers));