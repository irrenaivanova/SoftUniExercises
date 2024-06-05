string[] input = Console.ReadLine().Split(", ");
List<Lesson> lessons = new List<Lesson>();

for (int i = 0; i < input.Length; i++)
{
    string[] newLessons = input[i].Split("-");
    if (newLessons.Length == 1)

    { lessons.Add(new Lesson(newLessons[0], 0)); }
    else
    {
        if (lessons.Select(x => x.Name).Contains(newLessons[0]))
        {
            lessons.First(x => x.Name == newLessons[0]).Exercise = 1;
        }
        else
        {
            lessons.Add(new Lesson("no", 1));
        }
    }
}

while (true)
{
    string commandLine = Console.ReadLine();
    if (commandLine == "course start")
        break;
    string[] commandInput = commandLine.Split(":");
    string command = commandInput[0];
    string lessonTitle = commandInput[1];

    if (command == "Add" && !lessons.Select(x => x.Name).Contains(lessonTitle))
    {
        lessons.Add(new Lesson(lessonTitle, 0));
    }
    else if (command == "Insert" && !lessons.Select(x => x.Name).Contains(lessonTitle))
    {
        int index = int.Parse(commandInput[2]);
        if (index < 0 || index >= lessons.Count)
            continue;

        lessons.Insert(index, new Lesson(lessonTitle, 0));
    }
    else if (command == "Remove" && lessons.Select(x => x.Name).Contains(lessonTitle))
    {
        lessons.Remove(lessons.First(x => x.Name == lessonTitle));
    }
    else if (command == "Swap" && (lessons.Select(x => x.Name).Contains(lessonTitle)) && lessons.Select(x => x.Name).Contains(commandInput[2]))
    {
        int index1 = -1;
        int index2 = -1;
        for (int i = 0; i < lessons.Count; i++)
        {
            if (lessons[i].Name == lessonTitle)
            {
                index1 = i;
            }
        }
        for (int i = 0; i < lessons.Count; i++)
        {
            if (lessons[i].Name == commandInput[2])
            {
                index2 = i;
            }
        }

        Lesson temp = new Lesson();
        temp = lessons[index1];
        lessons[index1] = lessons[index2];
        lessons[index2] = temp;
    }
    else if (command == "Exercise")
    {
        if (!lessons.Select(x => x.Name).Contains(lessonTitle))
        {
            lessons.Add(new Lesson(lessonTitle, 1));
        }
        else
            lessons.First(x => x.Name == lessonTitle).Exercise = 1;
    }
}
int n = 1;
foreach (var item in lessons)
{
    if (item.Exercise == 0)
    {
        Console.WriteLine($"{n}.{item.Name}");
    }
    if (item.Exercise == 1)
    {
        if (item.Name == "no")
        {
            Console.WriteLine($"{n + 1}.{item.Name}-Exercise");
        }
        else
        {
            Console.WriteLine($"{n}.{item.Name}");
            Console.WriteLine($"{n + 1}.{item.Name}-Exercise");
            n++;
        }
    }
    n++;
}
//Data Types, Objects, Lists
//Exercise:Data Types
//Exercise:Databases
//Swap:Data Types:Lists
//course start



class Lesson
{
    public Lesson()
    { }
    public Lesson(string name, int exercise)
    {
        Name = name;
        Exercise = exercise;
    }
    public string Name { get; set; }
    public int Exercise { get; set; }

}