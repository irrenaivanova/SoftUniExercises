﻿using System.Text;

int n = int.Parse(Console.ReadLine());

Console.Write(new string('_', n / 2 + 2));
Console.Write('^');
Console.Write(new string('_', n / 2 + 2));
Console.WriteLine();

Console.Write(new string('_', n / 2 + 1));
Console.Write("/|\\");
Console.Write(new string('_', n / 2 + 1));
Console.WriteLine();


for (int i = n/2; i >=0; i--)
{
    Console.Write(new string('_', i));
    Console.Write('/');
    Console.Write(new string('.', n/2-i));
    Console.Write(new string('|', 3));
    Console.Write(new string('.', n / 2 - i));
    Console.Write('\\');
    Console.Write(new string('_', i));
    Console.WriteLine();
}
Console.Write("_/");
Console.Write(new string('.', n / 2 - 1));
Console.Write(new string('|', 3));
Console.Write(new string('.', n / 2 - 1));
Console.Write("\\_");
Console.WriteLine();


for (int i = 0; i < n; i++)
{
    Console.Write(new string('_', n/2+1));
    Console.Write(new string('|', 3));
    Console.Write(new string('_', n / 2+1));
    Console.WriteLine();
}

    Console.Write(new string('_', n / 2 + 1));
    Console.Write(new string('~', 3));
    Console.Write(new string('_', n / 2 + 1));
    Console.WriteLine();

for (int i = 0; i < n / 2; i++)
{
    Console.Write(new string('_', n / 2 - i));
    Console.Write(new string('/', 2));
    Console.Write(new string('.', i));
    Console.Write('!');
    Console.Write(new string('.', i));
    Console.Write(new string('\\', 2));
    Console.Write(new string('_', n / 2 - i));
    Console.WriteLine();
}
