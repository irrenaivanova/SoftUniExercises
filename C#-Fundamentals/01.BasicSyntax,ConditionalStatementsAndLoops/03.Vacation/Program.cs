int n = int.Parse(Console.ReadLine());
string type = Console.ReadLine();
string day = Console.ReadLine();
double price = 0;

switch (type)
{
    case "Students":
        if (day == "Friday")
            price = 8.45;
        else if (day == "Saturday")
            price = 9.80;
        else if (day == "Sunday")
            price = 10.46;
        if (n >= 30)
            price *= 0.85;
        break;

    case "Business":
        if (day == "Friday")
            price = 10.90;
        else if (day == "Saturday")
            price = 15.60;
        else if (day == "Sunday")
            price = 16;
        if (n >= 100)
            n -= 10;
        break;

    case "Regular":
        if (day == "Friday")
            price = 15;
        else if (day == "Saturday")
            price = 20;
        else if (day == "Sunday")
            price = 22.50;
        if (n >= 10 && n <= 20)
            price *= 0.95;
        break;
}
Console.WriteLine($"Total price: {price * n:F2}");
