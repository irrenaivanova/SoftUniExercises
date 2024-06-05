using _01.GenericBoxOfString;

int n = int.Parse(Console.ReadLine());
Box<string> box = new Box<string>();

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
box.Swap(numbers[0], numbers[1]);

Console.WriteLine(box.ToString());