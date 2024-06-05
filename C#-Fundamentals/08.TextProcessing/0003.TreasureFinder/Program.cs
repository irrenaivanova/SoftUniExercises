using System;
using System.Text;

int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();
while (true)
{
    string input = Console.ReadLine();
    StringBuilder decrypted = new StringBuilder();

    if (input == "find")
        break;

    //ako e po - malyk klu4a ot stringa

    int n = 0;
    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < key.Length; j++)
        {
            if (i == j || i == n * key.Length + j)
            {
                decrypted.Append((char)(input[i] - key[j]));
            }
        }

        if (i == (n + 1) * key.Length - 1)
            n++;
    }
    string decryptedString = decrypted.ToString();
    int startType = decryptedString.IndexOf('&');
    int endType = decryptedString.IndexOf('&', decryptedString.IndexOf('&') + 1);
    int startCoor = decryptedString.IndexOf('<');
    int endCoor = decryptedString.IndexOf('>');

    string type = decryptedString.Substring(startType + 1, endType - startType - 1);
    string coor = decryptedString.Substring(startCoor + 1, endCoor - startCoor - 1);

    Console.WriteLine($"Found {type} at {coor}");
}