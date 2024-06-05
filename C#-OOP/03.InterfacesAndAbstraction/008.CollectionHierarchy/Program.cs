

using _008.CollectionHierarchy.Models;
using _008.CollectionHierarchy.Models.Interfaces;

List<IAdd> collections = new() { new AddColection(), new AddRemoveCollection(), new MyList()};

string[] input = Console.ReadLine().Split();

List<int[]> adding = new List<int[]>();

foreach (var collection in collections)
{
	int[] output = new int[input.Length];
	for (int i = 0; i < input.Length; i++)
	{
		output[i] = collection.Add(input[i]);
	}
    adding.Add(output);
}

int numberToRemove = int.Parse(Console.ReadLine());

List<string>[] removing= new List<string>[2];
for (int i = 1; i < 3; i++)
{
	removing[i - 1] = new List<string>();
	for (int j = 0; j < numberToRemove; j++)
	{
		removing[i - 1].Add((collections[i] as IAddRemove).Remove());
	}
}

foreach (var arr in adding)
{
    Console.WriteLine(string.Join(" ",arr));
}
Console.WriteLine(string.Join("\n",removing.Select(x=>string.Join(" ",x))));