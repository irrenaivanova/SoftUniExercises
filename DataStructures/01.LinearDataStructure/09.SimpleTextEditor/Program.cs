using System.Text;

int n = int.Parse(Console.ReadLine());
Stack<string[]> stack = new Stack<string[]>();
StringBuilder sb = new StringBuilder();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();
    int command = int.Parse(input[0]);
    if (command == 1)
    {
        sb.Append(input[1]);
        stack.Push(new string[] { "1", input[1] });
    }

    if (command == 2)
    {
        int count = int.Parse(input[1]);
        string substring = sb.ToString().Substring(sb.Length-count);
        sb.Remove(sb.Length - count,count);
        stack.Push(new string[] { "2",substring });
    }

    if (command == 3)
    {
        Console.WriteLine(sb[int.Parse(input[1])-1]);
    }

    if (command == 4)
    {
        if (stack.Count <= 0)
        {
            continue;
        }
        string[] oper = stack.Pop();
        if (oper[0]=="1")
        {
            int count = oper[1].Length;
            sb.Remove(sb.Length - count, count);
        }
        if (oper[0] == "2")
        {
            sb.Append(oper[1]);
        }
    }
}