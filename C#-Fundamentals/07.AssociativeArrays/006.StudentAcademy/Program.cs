int n = int.Parse(Console.ReadLine());
Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

for (int i = 0; i < n; i++)
{
    string name = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

    if (!students.ContainsKey(name))
    {
        students.Add(name, new List<double>() { grade });
    }
    else
        students[name].Add(grade);
}
students = students.Where(x => x.Value.Average() >= 4.5)
    .ToDictionary(x => x.Key, x => x.Value);
foreach (var item in students)
{
    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
}