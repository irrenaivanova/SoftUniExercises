int[] numbers =Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> stack= new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

for (int i = 0; i < numbers[1]; i++)
{
    if (stack.Count()!=0)
    {
        stack.Pop();
    }
}
if (stack.Count()==0)
{
    Console.WriteLine("0");
    return;
}
int min = int.MaxValue;
while(stack.Count()!=0)
{
    int number = stack.Pop();
    if (number == numbers[2])
    {
        Console.WriteLine("true");
        return;
    }
    if (number < min)
    {
        min = number;
    }
}
Console.WriteLine(min);