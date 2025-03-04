int n = int.Parse(Console.ReadLine()!);
List<Sample> samples = new List<Sample>();
int index = 1;
while (true)
{
    string input = Console.ReadLine()!;
    if (input == "Clone them!")
    {
        break;
    }

    int[] inputDna = input.Split('!',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    var newSample = new Sample(index++, inputDna.Sum(), inputDna.ToList());
    int currentCount = 0;
    int maxCount = 0;
    int startIndex = 0;
    int tempIndex = 0;

    for (int i = 0; i < inputDna.Length; i++)
    {
        if (inputDna[i] == 1)
        {
            currentCount++;
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                startIndex = tempIndex;
            }
        }
        else
        {
            tempIndex = i + 1;
            currentCount = 0;
        }
    }

    newSample.IndexMaxSeq = startIndex;
    newSample.MaxLength = maxCount;
    samples.Add(newSample);
}


var result = samples.OrderByDescending(x => x.MaxLength).ThenBy(x => x.IndexMaxSeq).ThenByDescending(x => x.Sum).FirstOrDefault()!;
Console.WriteLine($"Best DNA sample {result.Index} with sum: {result.Sum}.");
Console.WriteLine(string.Join(" ",result.Dna));


public class Sample
{
    public Sample(int index, int sum, List<int> dna)
    {
        Index = index;
        Sum = sum;
        Dna = dna;
    }

    public int Index { get; set; }
    public int MaxLength { get; set;}

    public int IndexMaxSeq { get; set; }

    public int Sum { get; set; }

    public List<int> Dna { get; set; } = new List<int>();
}