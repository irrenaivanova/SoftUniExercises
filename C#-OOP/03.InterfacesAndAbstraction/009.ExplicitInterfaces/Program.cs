using _009.ExplicitInterfaces.Models;
using _009.ExplicitInterfaces.Models.Interfaces;

List<Citizen> people = new();
while (true)
{
    string[] input = Console.ReadLine().Split();
    if (input[0] == "End")
        break;

    people.Add (new Citizen(input[0], input[1], int.Parse(input[2])));
}

foreach (var person in people)
{
    Console.WriteLine(((IPerson)person).GetName());
    Console.WriteLine(((IResident)person).GetName());
}