
string[] girlsInput = Console.ReadLine().Split(", ");
string[] boysInput = Console.ReadLine().Split(", ");
List<string> girls = MakeTheCombination(girlsInput, 3);
List<string> boys = MakeTheCombination(boysInput, 2);
List<string> final = new List<string>();

for (int i = 0; i < girls.Count; i++)
{
    for (int j = 0; j < boys.Count; j++)
    {
        final.Add(girls[i] + ", " + boys[j]);
    }
}

Console.WriteLine(string.Join("\n",final));
List<string> MakeTheCombination(string[] input, int n)
{
    List<string> kids = new();
    string[] combKids = new string[n];

    Combination(0, 0);
    void Combination(int start, int element)
    {
        if (start == combKids.Length)
        {
            kids.Add(string.Join(", ", combKids));
            return;
        }

        for (int i = element; i < input.Length; i++)
        {
            combKids[start] = input[i];
            Combination(start + 1, i + 1);
        }
    }
    return kids;
}

