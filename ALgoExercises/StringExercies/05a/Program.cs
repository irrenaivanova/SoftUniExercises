int input = int.Parse(Console.ReadLine()!);


while(input != 0)
{
    int lastDigit = input % 10;
    Console.WriteLine(lastDigit);
    input = input / 10;
}