using System.Xml.Linq;

XDocument xml = XDocument.Load("xmlDemo.xml");
var booksatt = xml.Root.Attributes();
Console.WriteLine(string.Join(", ",booksatt));

var books = xml.Root.Elements();
foreach (var book in books)
{
    Console.WriteLine($"{book.Name} - {book.Value}");
}

foreach (var book in books)
{
    string tittle = book.Element("title").Value;
    string author = book.Element("author").Value;
    Console.WriteLine($"{tittle} - {author}");
}

foreach (var child in books)
{
    child.SetElementValue("price", 1.20);
}
xml.Save("Data_new.hml");

var title = books.Select(x => new
{
    Name = x.Element("title").Value,
    Isbn = x.Element("isbn").Value
})
    .OrderByDescending(x => x.Isbn).Select(x => x.Name).FirstOrDefault();
Console.WriteLine(title);

XDocument doc = new XDocument();
var root = new XElement("library");
doc.Add(root);
for (int i = 0; i < 20; i++)
{
    var book = new XElement("book");
    root.Add(book);
    var title2 = new XElement("title");
    book.Add(title);
    var subtitle = new XElement("subtitle", "sub" + i);
    title2.Add(subtitle);
}

doc.Save("@../../../../../new.xml");
