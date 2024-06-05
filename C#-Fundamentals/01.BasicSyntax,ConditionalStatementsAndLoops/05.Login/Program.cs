string username = Console.ReadLine();
string password = Console.ReadLine();
string correctPass = string.Empty;
int times = 0;
bool isItfound = false;
bool isItblosked = false;

for (int i = username.Length - 1; i >= 0; i--)
{
    correctPass += username[i];
}

while (password != correctPass)
{
    times++;
    if (times == 4)
    {
        Console.WriteLine($"User {username} blocked!");
        break;
    }
    Console.WriteLine("Incorrect password. Try again.");
    password = Console.ReadLine();
}

if (times < 4)
    Console.WriteLine($"User {username} logged in.");