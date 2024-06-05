using _07.Tuple;
using System;

string[] input = Console.ReadLine().Split();

MyTuple<string, string> first = new MyTuple<string, string> ($"{input[0]} {input[1]}", input[2]); 

string[] amounBeer = Console.ReadLine().Split();

MyTuple<string,int> second = new MyTuple<string, int>(amounBeer[0], int.Parse(amounBeer[1]));

string[] numbers = Console.ReadLine().Split();

MyTuple<int,double> third = new MyTuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

Console.WriteLine(first);
Console.WriteLine(second);
Console.WriteLine(third);