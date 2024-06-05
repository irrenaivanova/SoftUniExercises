string[] file = Console.ReadLine().Split("\\");
string[] last = file[file.Length - 1].Split(".");

Console.WriteLine($"File name: {last[0]}");
Console.WriteLine($"File extension: {last[1]}");
