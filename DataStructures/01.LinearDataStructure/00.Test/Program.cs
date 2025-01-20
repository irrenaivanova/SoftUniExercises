

int n = int.Parse(Console.ReadLine());
int count = 0;
Algorthm(n);
Console.WriteLine(count);

void Algorthm(int n)
{
    if (n == 0)
    {
        return;
    }
    count++;
    Console.WriteLine(n);
    Algorthm(n - 1);
    Console.WriteLine(n);
    Algorthm(n - 1);
    Console.WriteLine(n);
    Algorthm(n - 1);
}