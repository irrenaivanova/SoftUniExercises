using System.Linq;

List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
string manipul = Console.ReadLine();
Func<int, int> func = x =>
{
    if (manipul =="multiply")
    {
        return x *= 2;
    }
    return 0;
};


Console.WriteLine(string.Join(" ",input.Select(func)));

//var output = 