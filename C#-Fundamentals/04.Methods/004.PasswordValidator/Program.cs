string password = Console.ReadLine();
IsItValid(password);

void IsItValid(string password)
{
    if (!Bewteen6And10Char(password))
        Console.WriteLine("Password must be between 6 and 10 characters");
    if (!OnlyLetterAndDigits(password))
        Console.WriteLine("Password must consist only of letters and digits");
    if (!AtLeastTwoDIgits(password))
        Console.WriteLine("Password must have at least 2 digits");
    if (Bewteen6And10Char(password) && OnlyLetterAndDigits(password) && AtLeastTwoDIgits(password))
        Console.WriteLine("Password is valid");
}


bool Bewteen6And10Char(string password)
{
    if (password.Length >= 6 && password.Length <= 10)
        return true;
    else
        return false;
}
bool OnlyLetterAndDigits(string password)
{
    int count = 0;
    for (int i = 0; i < password.Length; i++)
    {
        int a = Convert.ToInt32(password[i]);
        if ((a >= 48 && a <= 57) || (a >= 97 && a <= 122) || (a >= 65 && a <= 90))
            count++;
    }
    if (count == password.Length)
        return true;
    else
        return false;
}
bool AtLeastTwoDIgits(string password)
{

    int count = 0;
    for (int i = 0; i < password.Length; i++)
    {
        int a = Convert.ToInt32(password[i]);
        if (a >= 48 && a <= 57)
            count++;
    }
    if (count >= 2)
        return true;
    else
        return false;
}