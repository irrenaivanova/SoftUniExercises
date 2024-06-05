using CostumListNamespace;

CostumList2 list = new CostumList2();
list.Add(5);
list.Add(6);
list.Add(7);
list.Add(8);
list.Add(9);
list.Add(10);
list.Add(11);




list[0] = 101;

int number = list.RemoveAt(2);
list.Insert(2, 105);

Console.WriteLine(number);