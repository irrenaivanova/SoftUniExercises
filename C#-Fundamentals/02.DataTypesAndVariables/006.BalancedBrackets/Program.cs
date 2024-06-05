int n = int.Parse(Console.ReadLine());
bool isBalanced = false;
int times = 0;
string balance = String.Empty;

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    if (char.TryParse(input, out _))
    {
        int number = Convert.ToInt32(Convert.ToChar(input));
        if (number == 40 || number == 41)
            balance += number;
        if (balance == "4041")
        {
            balance = String.Empty;
            times++;
        }
    }
}
if (balance != String.Empty)
    Console.WriteLine("UNBALANCED");
else if (balance == String.Empty && times > 0)
    Console.WriteLine("BALANCED");