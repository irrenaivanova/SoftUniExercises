string[] input = Console.ReadLine()!.Split(", ");
List<string> output = input.Where(x => x.Length > 3 && 
                                       x.Length < 16 && 
                                       x.All(c => char.IsLetterOrDigit(c) ||  c == '-' || c == '_'))
                           .ToList();

//foreach (string name in input)
//{
//    if (name.Length < 3 || name.Length > 16)
//    {
//        continue;
//    }
//    bool isValid = true;

//    for (int i = 0; i < name.Length; i++)
//    {
//        if (!(char.IsLetterOrDigit(name[i]) || name[i] == '-' || name[i] == '_'))
//        {
//            isValid = false;
//            break;
//        }
//    }
//    if (!isValid)
//    {
//        continue;
//    }
//    output.Add(name);
//}
Console.WriteLine(string.Join("\n",output));