using _01.GenericBoxOfString;

int n = int.Parse(Console.ReadLine());
Box<string> box = new Box<string>();

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

Box<int> box2 = new Box<int>();
for (int i = 0; i < n; i++)
{
    box2.Add(int.Parse(Console.ReadLine()));
}

Console.WriteLine(box.ToString());
Console.WriteLine(box2.ToString());