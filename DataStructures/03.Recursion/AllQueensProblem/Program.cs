using AllQueensProblem;

int n = int.Parse(Console.ReadLine()!);

var solver = new AllQueensSolver(n);
Console.WriteLine($"The number of unique solutions is: {solver.GetTheNumberOfSolutions()}");
solver.PrintTheSolutions();
