using _004.BorderControl.Models;
using _004.BorderControl.Models.Interfaces;

List<IIdentifiable> list = new();
while(true)
{
    string[] input = Console.ReadLine().Split();
    if (input[0] == "End")
        break;

    if (input.Length==2)
    {
        list.Add(new Robot(input[0], input[1]));
    }
    if (input.Length == 3)
    {
        list.Add(new Citizens(input[0],int.Parse(input[1]), input[2]));
    }
}
string fakeIdConst = Console.ReadLine();

Console.WriteLine(string.Join("\n",list.Where(x=>x.Id.EndsWith(fakeIdConst))));
