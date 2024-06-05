

using _005.BirthdayCelebrations.Models;
using _005.BirthdayCelebrations.Models.Interfaces;

List<IBirthdable> list = new List<IBirthdable>();
while (true)
{
    string[] input = Console.ReadLine().Split();
    if (input[0]=="End")
    {
        break;
    }
    if (input[0]=="Citizen")
    {
        list.Add(new Citizens(input[1], int.Parse(input[2]), input[3], input[4]));
    }
    if (input[0] == "Pet")
    {
        list.Add(new Pet(input[1], input[2]));
    }
}

string year = Console.ReadLine();
list = list.Where(x=>x.Birthday.EndsWith(year)).ToList();
Console.WriteLine(string.Join('\n',list.Select(x=>x.Birthday)));