int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());
string filter = Console.ReadLine();

//Predicate<int> predicate = x =>
//{
//    if(filter=="odd")
//    {
//        return x%2 != 0;    
//    }
//    if (filter == "even")
//    {
//        return x % 2 == 0;
//    }
//    return false;
//};

//Console.WriteLine(string.Join(" ",Enumerable.Range(start,end-start+1).Where(x=>predicate(x))));

Func<int,bool> predicate = x =>
{
    if (filter == "odd")
    {
        return x % 2 != 0;
    }
    if (filter == "even")
    {
        return x % 2 == 0;
    }
    return false;
};

Console.WriteLine(string.Join(" ", Enumerable.Range(start, end - start + 1).Where(predicate)));