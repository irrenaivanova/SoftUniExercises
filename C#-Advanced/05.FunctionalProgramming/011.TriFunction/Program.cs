int n = int.Parse(Console.ReadLine());
List<string> names = Console.ReadLine().Split().ToList();

Func<string, int> number = x => x.Sum(ch => ch);

//Func<string, int> number = x =>
//{
//    int sum = 0;
//    foreach (char letter in x)
//    {
//        sum += letter;
//    }
//    return sum;
//};

Func<int, int, bool> ifLonger = (x, y) => x >= y;
string theName = names.First(x => ifLonger(number(x), n));

Console.WriteLine(theName);