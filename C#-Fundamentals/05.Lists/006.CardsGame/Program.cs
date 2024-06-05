using System.Numerics;

List<int> player1Cards = Console.ReadLine().Split().Select(int.Parse).ToList();
List<int> player2Cards = Console.ReadLine().Split().Select(int.Parse).ToList();

while (player1Cards.Count != 0 && player2Cards.Count != 0)
{
    int currCard1 = player1Cards[0];
    int currCard2 = player2Cards[0];

    player1Cards.RemoveAt(0);
    player2Cards.RemoveAt(0);

    if (currCard1 > currCard2)
    {
        player1Cards.Add(currCard2);
        player1Cards.Add(currCard1);
    }
    else if (currCard1 < currCard2)
    {
        player2Cards.Add(currCard1);
        player2Cards.Add(currCard2);
    }
}
int sum1 = player1Cards.Sum();
int sum2 = player2Cards.Sum();
if (player1Cards.Count == 0)
    Console.WriteLine($"Second player wins! Sum: {sum2}");
else if (player2Cards.Count == 0)
    Console.WriteLine($"First player wins! Sum: {sum1}");


//Console.WriteLine(string.Join(" ",player1Cards));
//Console.WriteLine(string.Join(" ", player2Cards));
