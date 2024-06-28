Stack<int> packages = new(Console.ReadLine().Split().Select(int.Parse));
Queue<int> couries = new(Console.ReadLine().Split().Select(int.Parse));
int weight = 0;

while(true)
{
    if (!packages.Any() || !couries.Any())
    {
        break;
    }
    int pack = packages.Peek();
    int cour = couries.Peek();
    
    if (cour==pack)
    {
        packages.Pop();
        couries.Dequeue();
        weight += pack;
    }
    else if (cour>pack)
    {
        packages.Pop() ;
        couries.Dequeue() ;
        weight += pack ;
        cour -= pack * 2;
        if (cour>0)
        {
            couries.Enqueue(cour) ;
        }
    }
    else if (pack>cour)
    {
        packages.Pop() ;
        couries.Dequeue() ;
        pack -= cour;
        packages.Push(pack) ;
        weight += cour ;
    }
}

Console.WriteLine($"Total weight: {weight} kg");
if (!packages.Any() && !couries.Any())
{
    Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
}
if (packages.Any() && !couries.Any())
{
    Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ",packages)}");
}
if (!packages.Any() && couries.Any())
{
    Console.WriteLine($"Couriers are still on duty: {string.Join(", ",couries)} but there are no more packages to deliver.");
}