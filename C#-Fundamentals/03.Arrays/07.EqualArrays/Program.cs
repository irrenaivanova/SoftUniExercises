int[] string1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] string2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
int sum = 0;
bool areIdentical = true;
for (int i = 0; i < string1.Length; i++)
{
    if (string1[i] == string2[i])
    {
        sum += string1[i];
    }
    else
    {
        areIdentical = false;
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        break;
    }
}
if (areIdentical)
    Console.WriteLine($"Arrays are identical. Sum: {sum}");