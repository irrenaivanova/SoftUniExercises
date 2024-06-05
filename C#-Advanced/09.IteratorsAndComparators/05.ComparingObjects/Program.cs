using _05.ComparingObjects;

List<Person> people = new List<Person>();
while(true)
{
    string[] command = Console.ReadLine().Split();

    if (command[0]=="END")
    {
        break;
    }

    people.Add(new Person(command[0], int.Parse(command[1]), command[2]));
}

int index = int.Parse(Console.ReadLine()) -1;
Person personToCompare = people[index];

int matches = 0;
int notEqual = 0;

//StudentComparer studentComparer = new StudentComparer();
//for (int i = 0; i < people.Count; i++)
//{
//    if (studentComparer.Compare(people[i],personToCompare)==0)
//    {
//        matches++;
//    }
//    else 
//        notEqual++;
//}

for (int i = 0; i < people.Count; i++)
{
    if (people[i].CompareTo(personToCompare) == 0)
    {
        matches++;
    }
    else
        notEqual++;
}


if (matches!=1)
    Console.WriteLine($"{matches} {notEqual} {people.Count}");
else
    Console.WriteLine("No matches");
