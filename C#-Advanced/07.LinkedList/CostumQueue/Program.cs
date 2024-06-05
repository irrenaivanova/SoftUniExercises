
using CostumQueue;

CostumSoftUniQueue list = new CostumSoftUniQueue();

list.Enqueue(2);
list.Enqueue(3);
list.Enqueue(4);
    
list.Enqueue(5);
list.Enqueue(6);

list.Dequeue();
list.Enqueue(7);

list.Print();