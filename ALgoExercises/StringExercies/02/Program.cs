string[] input = Console.ReadLine()!.Split(" ");
int sum = 0;

int minLength = Math.Min(input[0].Length, input[1].Length);
for (int i = 0; i < minLength; i++)
{
    sum += input[0][i] * input[1][i];
}

for (int i = minLength; i < input[0].Length; i++)
{
    sum += input[0][i];
}

for (int i = minLength; i < input[1].Length; i++)
{
    sum += input[1][i];
}

Console.WriteLine(sum);