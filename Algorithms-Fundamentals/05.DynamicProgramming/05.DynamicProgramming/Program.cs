int n = int.Parse(Console.ReadLine());

long[] array = new long[n+1];

array[0] = 0;
array[1] = 1;

for (int i = 2; i <= n; i++)
{
    array[i] = array[i - 2] + array[i - 1];
}
Console.WriteLine(array[n]);


//Console.WriteLine(Fibonachi(n));

//int Fibonachi(int n)
//{
//    if (n==0)
//    {
//        return 0;
//    }
//    if (n==1) 
//    {
//        return 1;
    
//    }
//    return Fibonachi(n - 1) + Fibonachi(n - 2);
//}