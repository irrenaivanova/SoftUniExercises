using _07.Tuple;
using System;

string[] input = Console.ReadLine().Split();

MyThreeuple<string, string,string> first = new ($"{input[0]} {input[1]}", input[2], input[3]);

string[] amounBeer = Console.ReadLine().Split();

MyThreeuple<string, int, bool> second = new (amounBeer[0], int.Parse(amounBeer[1]), amounBeer[2]=="drunk" ? true:false);

string[] numbers = Console.ReadLine().Split();

MyThreeuple<string,double,string> third = new (numbers[0], double.Parse(numbers[1]), numbers[2]);

Console.WriteLine(first);
Console.WriteLine(second);
Console.WriteLine(third); 