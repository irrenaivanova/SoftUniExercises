using CostumStack;

CostumSoftUniStack list = new CostumSoftUniStack();

list.Push(2);
list.Push(3);
list.Push(4);
list.Push(5);
list.Push(6);
    
list.Push(7);
int count = list.Count;

int number = list.Pop();

Console.WriteLine(number);