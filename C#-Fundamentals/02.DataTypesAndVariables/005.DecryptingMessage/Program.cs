int key = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());
string text = String.Empty;

for (int i = 1; i <= n; i++)
{
    char input = char.Parse(Console.ReadLine());
    int number = Convert.ToInt32(input);
    text += (Convert.ToChar(number + key));
}
Console.WriteLine(text);