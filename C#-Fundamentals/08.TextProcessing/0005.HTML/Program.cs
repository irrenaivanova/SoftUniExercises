string title = Console.ReadLine();
string content = Console.ReadLine();
List<string> comments = new List<string>();
while (true)
{
    string comment = Console.ReadLine();
    if (comment == "end of comments")
        break;
    comments.Add(comment);
}

Console.WriteLine($"<h1> \n{title}\n</h1>\n<article>\n{content}\n</article>");

foreach (var comment in comments)
{
    Console.WriteLine($"<div>\n{comment}\n</div>");
}