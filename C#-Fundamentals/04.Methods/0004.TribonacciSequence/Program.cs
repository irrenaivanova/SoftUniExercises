int n = int.Parse(Console.ReadLine());

int[] tribonachi = new int[n];
if (n == 1)
    Console.WriteLine("1");
else if (n == 2)
    Console.WriteLine("1 1");
else
{
    int[] currTrib = new int[n];
    currTrib[0] = tribonachi[0] = 1;
    currTrib[1] = tribonachi[1] = 1;
    currTrib[2] = tribonachi[2] = 2;
    for (int i = 3; i < tribonachi.Length; i++)
    {
        tribonachi[i] = currTrib[i - 1] + currTrib[i - 2] + currTrib[i - 3];
        currTrib = tribonachi;
    }
    Console.WriteLine(string.Join(" ", tribonachi));
}