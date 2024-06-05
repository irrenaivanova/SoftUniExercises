
using CostumHashTag;
using System.Collections.Generic;
using System.Diagnostics;

int elementsCount = 100000;
int elementsToFind = 10000000;
Stopwatch stopwatch = new Stopwatch();

//stopwatch.Start();
//List<string> list = new();
//for (int i = 0; i < elementsCount; i++)
//{
//    list.Add($"Dani{i.ToString()}");
//}
//stopwatch.Stop();
//Console.WriteLine($"Time adding with list:{stopwatch.ElapsedMilliseconds}");
//stopwatch.Reset();

stopwatch.Start();
CostumHashSet set = new CostumHashSet();
for (int i = 0; i < elementsCount; i++)
{
    set.Add($"Dani{i.ToString()}");
}
stopwatch.Stop();
Console.WriteLine($"Time adding with hashset:{stopwatch.ElapsedMilliseconds}");
stopwatch.Reset();

//stopwatch.Start();
//MeasureList(elementsToFind);
//stopwatch.Stop();
//Console.WriteLine($"Time with list:{stopwatch.ElapsedMilliseconds}");
//stopwatch.Reset();

stopwatch.Start();
MeasureSoftUniSet(elementsToFind);
stopwatch.Stop();
Console.WriteLine($"Time with hashset:{stopwatch.ElapsedMilliseconds}");


//void MeasureList(int elementsToFind)
//{
   
//    for (int i = 0; i < elementsToFind; i++)
//    {
//        list.Contains($"Dani{i.ToString()}");
//    }
//}
void MeasureSoftUniSet(int elementsToFind)
{
    for (int i = 0; i < elementsToFind; i++)
    {
        set.Contains($"Dani{i.ToString()}");
    }
}