
List<Card> cards = new();
Dictionary<string, char> suits = new()
    {
        { "S",'\u2660' },
        { "H",'\u2665' },
        {"D",'\u2666' },
        {"C",'\u2663' }
    };
string[] cardsInput = Console.ReadLine().Split(", ").ToArray();
foreach (var pair in cardsInput)
{
    string[] symbols = pair.Split();
    try
    {
        cards.Add(new Card().CreateCard(symbols[0], symbols[1]));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(" ", cards.Select(x => $"[{x.Face}{suits[x.Suit]}]")));

public class Card
{
    private const string faces = "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A";
    private const string suits = "SHDC";

    public Card()
    {
    }

    public string Face { get; private set; }
    public string Suit { get; private set; }

    public Card CreateCard(string face, string suit)
    {
        if (!faces.Contains(face) || !suits.Contains(suit))
        {
            throw new Exception("Invalid card!");
        }
        return new Card() { Face = face,Suit = suit};
    }
}

