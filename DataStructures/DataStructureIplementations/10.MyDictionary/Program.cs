using MyDictionary;

var dict = new MyDictionary<string, string>();
for (int i = 0; i < 200; i++)
{
    dict.Add(i.ToString(), $"{(i + 5).ToString()}Irrrr");
}

dict["0"] = "0883371278";

dict.Remove("1");

Console.WriteLine(dict.Contains("1"));
Console.WriteLine(dict["0"]);
