using System.Text;
List<NumberRepresentation> numbers = new List<NumberRepresentation>();
List<string> numbersInput = Console.ReadLine()!.Split().ToList();
var maxLength = numbersInput.OrderByDescending(x => x.Length).First().Length;

foreach (var number in numbersInput)
{
    if (number.Length < maxLength)
    {
        StringBuilder repr = new StringBuilder();
        repr.Append(number);
        for (int i = number.Length; i < maxLength; i++)
        {
            repr.Append(number[0]);
        }

        numbers.Add(new NumberRepresentation(number,repr.ToString().Trim()));
    }
    else
    {
        numbers.Add(new NumberRepresentation(number, number));
    }
}

numbers = numbers.OrderByDescending(x => x.Representation).ToList();
StringBuilder sb = new StringBuilder();
foreach (var number in numbers)
{
    sb.Append(number.Number);
}
Console.WriteLine(sb.ToString().Trim());





public class NumberRepresentation
{
    public NumberRepresentation(string number, string representation)
    {
        Number = number;
        Representation = representation;
    }

    public string Number { get; set; }

    public string Representation { get; set; }
}