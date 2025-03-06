string input = Console.ReadLine()!;
List<int> indexes = new List<int>();

int index = input.IndexOf('\\');

while(index >= 0)
{
    indexes.Add(index);
    index = input.IndexOf("\\", index+1);
}
Console.WriteLine(string.Join(" ", indexes));