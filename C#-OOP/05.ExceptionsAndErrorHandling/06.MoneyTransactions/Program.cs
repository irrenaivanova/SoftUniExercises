string[] input = Console.ReadLine().Split(',');
List<Account> accounts = new();

foreach (string accountinFo in input)
{
    string[] accountValues = accountinFo.Split("-");
    try
    {
        accounts.Add(new Account(int.Parse(accountValues[0]), double.Parse(accountValues[1])));
    }
    catch (FormatException)
    {
        Console.WriteLine($"Invalid input");
    }
}

while(true)
{
    string[] command = Console.ReadLine().Split();
    try
    {
        if (command[0] == "End")
        {
            break;
        }
        int accountNumber = int.Parse(command[1]);
        double sum = double.Parse(command[2]);

        if (command[0] == "Deposit")
        {
            Deposit(accountNumber, sum);
        }
        else if (command[0] == "Withdraw")
        {
            Withdrow(accountNumber, sum);
        }
        else  
        {
            throw new ArgumentException("Invalid command!");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Enter another command");

    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid format");
    }
}

void Withdrow(int accountNumber, double sum)
{
    if (IsValidAccountNumber(accountNumber) && IsSumEnough(accountNumber,sum))
    {
        Account current = accounts.FirstOrDefault(x => x.Number == accountNumber);
        current.Balance -= sum;
        Console.WriteLine(current);
    }
   
    Console.WriteLine("Enter another command");
}

void Deposit(int accountNumber, double sum)
{
    if (IsValidAccountNumber(accountNumber)) 
    {
        Account current = accounts.FirstOrDefault(x => x.Number == accountNumber);
        current.Balance+=sum;
        Console.WriteLine(current);
    }
    Console.WriteLine("Enter another command");
}

bool IsValidAccountNumber(int accountNumber)
{
    if (!accounts.Any(x=>x.Number==accountNumber))
    {
        throw new ArgumentException("Invalid account!");
    }
    return true;
}
bool IsSumEnough(int accountNumber, double sum)
{
    if (accounts.FirstOrDefault(x => x.Number == accountNumber).Balance < sum)
    {
        throw new ArgumentException("Insufficient balance!");
    }
    return true;
}
public class Account
{
    public Account(int number, double balance)
    {
        Number = number;
        Balance = balance;
    }

    public int Number { get;private set; }

    public double Balance { get;  set; }
    public override string ToString() => $"Account {Number} has new balance: {Balance:f2}";

}

