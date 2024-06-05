int n = int.Parse(Console.ReadLine());
double pHeadset = double.Parse(Console.ReadLine());
double pMouse = double.Parse(Console.ReadLine());
double pKeyboard = double.Parse(Console.ReadLine());
double pDisplayt = double.Parse(Console.ReadLine());
int p1 = n / 2;
int p2 = n / 3;
int p3 = n / 6;
int p4 = n / 12;

double expenses = pHeadset * p1 + pMouse * p2 + pKeyboard * p3 + pDisplayt * p4;

Console.WriteLine($"Rage expenses: {expenses:f2} lv.");