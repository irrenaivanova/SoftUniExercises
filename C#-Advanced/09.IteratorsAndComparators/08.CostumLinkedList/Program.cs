using CostumLinkedList;

SoftUniLinkedList list = new SoftUniLinkedList();
list.AddLast(1);
list.AddLast(2);
list.AddLast(3);
list.AddLast(4);
list.AddLast(5);


foreach (var item in list)
{
    Console.WriteLine(item);
}