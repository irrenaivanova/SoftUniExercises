using _01.GenericBoxOfString;

int n = int.Parse(Console.ReadLine());
Box<string> box = new();

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

string element = Console.ReadLine();

Console.WriteLine(box.BiggerValues(element));