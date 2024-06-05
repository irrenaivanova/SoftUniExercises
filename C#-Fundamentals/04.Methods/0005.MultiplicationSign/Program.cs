int[] numbers = new int[3] { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
int count = 0;
bool isZero = false;
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] == 0)
    {
        Console.WriteLine("zero");
        isZero = true;
        break;
    }
    if (numbers[i] < 0)
        count++;
}
if (!isZero && count % 2 == 0)
    Console.WriteLine("positive");
else if (!isZero && (count % 2 == 1 || count == 1))
    Console.WriteLine("negative");