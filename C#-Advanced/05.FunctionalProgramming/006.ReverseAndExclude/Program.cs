List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
int n = int.Parse(Console.ReadLine());

Predicate<double> filter = x => x % n != 0;

Func<List<double>, List<double>> reversed = (numbers) =>
{
    List<double> result = new List<double>();
    
    for (int i = numbers.Count-1; i >= 0; i--)
    {
        result.Add(numbers[i]);
    }
    return result;
};

Action<List<double>> printer = (x) => Console.WriteLine(string.Join(" ", x));

numbers = numbers.Where(x => filter(x)).ToList();
numbers = reversed(numbers);
printer(numbers);

