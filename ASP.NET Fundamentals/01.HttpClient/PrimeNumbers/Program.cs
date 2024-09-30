


using System.Text;

Task.Run(()=>PrintSome(10));

while(true)
{
    var input = Console.ReadLine();
    Console.WriteLine(input.ToUpper());
}
static void PrintSome(int number)
{
    StringBuilder sb = new StringBuilder();  

    for (int i = 0; i < number; i++)
    { 
        sb.AppendLine(i.ToString());
    }
    Console.WriteLine(sb.ToString());
}
