string input = Console.ReadLine()!;

var output = input.Select(x =>(char)(x + 3)).ToArray();
Console.WriteLine(string.Join("",output));