using _003.Articles2._0;

int n = int.Parse(Console.ReadLine());

List<Article> list = new List<Article>();

for (int i = 0; i < n; i++)
{
    string[] inputArticle = Console.ReadLine().Split(", ");
    list.Add(new Article(inputArticle[0], inputArticle[1], inputArticle[2]));
}

string criteria = Console.ReadLine();
if (criteria == "title")
{
    list = list.OrderBy(x => x.Title).ToList();
}
if (criteria == "content")
{
    list = list.OrderBy(x => x.Content).ToList();
}
if (criteria == "author")
{
    list = list.OrderBy(x => x.Author).ToList();
}

for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}

namespace _003.Articles2._0
{
    internal class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}