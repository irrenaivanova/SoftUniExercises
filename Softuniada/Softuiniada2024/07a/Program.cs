int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());

List<int> specialNumbrs = new List<int>();

for (int i = n; i <= m; i++)
{
    bool isSpecial = true;
    int number = i;
    int lastDigit = number % 10;
    number /= 10;
    
    while (number > 0)
    {
        int newlastDigit = number % 10;
        if (Math.Abs(newlastDigit-lastDigit)!=1)
        {
            isSpecial = false;
            break;
        }
        number /= 10;
        lastDigit = newlastDigit;
    }
    
    if (isSpecial)
    {
        specialNumbrs.Add(i);
    }
}
Console.WriteLine(string.Join("\n", specialNumbrs));