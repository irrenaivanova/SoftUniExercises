double budget = double.Parse(Console.ReadLine());
int students = int.Parse(Console.ReadLine());
double pLight = double.Parse(Console.ReadLine());
double pRobes = double.Parse(Console.ReadLine());
double pBelts = double.Parse(Console.ReadLine());


int amountBelt = (students / 6) * 5 + students % 6;

double total = pLight * Math.Ceiling(students * 1.1) + students * pRobes + amountBelt * pBelts;

if (budget >= total)
    Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
else
    Console.WriteLine($"John will need {(total - budget):f2}lv more.");
