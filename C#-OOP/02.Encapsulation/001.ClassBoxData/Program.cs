using _001.ClassBoxData;

double length = double.Parse(Console.ReadLine());
double width =  double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

Box box = new Box();
try
{
   box = new Box(length, width, height);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

Console.WriteLine(box);