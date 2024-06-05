Console.BufferHeight = Console.WindowHeight = 20;
Console.BufferWidth = Console.WindowWidth = 30;

Console.WriteLine("kjdksjdks");
void PrintingOnConsole (int x, int y, char c, ConsoleColor color = ConsoleColor.Magenta)
{
    Console.SetCursorPosition (x, y);
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = color;
    Console.Write(c);
}
//while (true)
//{
//    PrintingOnConsole(10, 10, '@');
//}

//ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//Console.WriteLine(keyInfo.KeyChar);
PrintingOnConsole(0, 10, '@', ConsoleColor.Red);