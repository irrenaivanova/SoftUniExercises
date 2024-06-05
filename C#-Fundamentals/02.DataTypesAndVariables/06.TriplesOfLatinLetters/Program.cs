int n = int.Parse(Console.ReadLine());

for (int x1 = 97; x1 < 97 + n; x1++)
{
    for (int x2 = 97; x2 < 97 + n; x2++)
    {
        for (int x3 = 97; x3 < 97 + n; x3++)
        {
            Console.WriteLine($"{Convert.ToChar(x1)}{Convert.ToChar(x2)}{Convert.ToChar(x3)}");
        }
    }
}