int n = int.Parse(Console.ReadLine());
int m =  int.Parse(Console.ReadLine()); 

List<int> specialNumbrs =  new List<int>();

for (int i = n; i <= m; i++)
{
    int number = i;
    List<int> lastdDigits = new();
    while (number>0)
    {
        int lastDigit = number % 10;
        lastdDigits.Add(lastDigit);
        number /= 10;
    }
    bool isSpecial = true; 
    for (int j = 0; j < lastdDigits.Count-1; j++)
    {
        if (Math.Abs(lastdDigits[j] - lastdDigits[j+1])!=1)
        {
            isSpecial = false;
            break;
        }
    }
    if (isSpecial) 
    {
        specialNumbrs.Add(i);
    }
}
Console.WriteLine(string.Join("\n", specialNumbrs));