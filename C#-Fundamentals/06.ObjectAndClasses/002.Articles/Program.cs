using _002.Articles;

string[] articleInput = Console.ReadLine().Split(", ");
Articles article1 = new Articles(articleInput[0], articleInput[1], articleInput[2]);

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] command = Console.ReadLine().Split(": ");
    if (command[0] == "Edit")
    {
        article1.EditContent(command[1]);
    }

    else if (command[0] == "ChangeAuthor")
    {
        article1.ChangeAuthor(command[1]);
    }

    else if (command[0] == "Rename")
    {
        article1.Rename(command[1]);
    }
}

Console.WriteLine($"{article1.Title} - {article1.Content}: {article1.Author}");


namespace _002.Articles
{
    public class Articles
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Articles(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string EditContent(string newContent)
        {
            return Content = newContent;
        }
        public string ChangeAuthor(string newAuthor)
        { return Author = newAuthor; }

        public string Rename(string newTitle)
        {
            return Title = newTitle;
        }
    }
}