namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;
    using Z.EntityFramework.Plus;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //string command = Console.ReadLine();
            //string result2 = GetBooksByAgeRestriction(db, command);
            //string result2 = GetGoldenBooks(db);
            //string result4 = GetBooksByPrice(db);
            //int year = int.Parse(Console.ReadLine());
            //string result5 = GetBooksNotReleasedIn(db, year);
            //string input = Console.ReadLine();
            //string result6 = GetBooksByCategory(db, input);
            //string date = Console.ReadLine();
            //string result7 = GetBooksReleasedBefore(db, date);
            //string input = Console.ReadLine();
            //string result8 = GetAuthorNamesEndingIn(db, input);
            //string input = Console.ReadLine();
            //string result9 = GetBookTitlesContaining(db, input);
            //int input = int.Parse(Console.ReadLine());
            //string result10 = GetMostRecentBooks(db);
            //Console.WriteLine(result10);
            IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db));



        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new();
            AgeRestriction restriction = new AgeRestriction();
            Enum.TryParse(command, true, out restriction);
            var booksTitle = context.Books.Where(x => x.AgeRestriction == restriction)
                .OrderBy(x=>x.Title)
                .Select (x=>x.Title)
                .ToList();
            return string.Join("\n", booksTitle);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(x=>x.Copies<5000 && x.EditionType==EditionType.Gold)
                    .OrderBy(x=>x.BookId)
                    .Select(x=>x.Title).ToList();
            return string.Join("\n", books);

        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                }).ToArray();
            return string.Join("\n", books.Select(x => $"{x.Title} - ${x.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booktitles = context.Books.Where(x=>x.ReleaseDate.Value.Year!=year)
                .OrderBy(x=>x.BookId)
                .Select(x=>x.Title)
                .ToArray();
            return string.Join("\n", booktitles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] tokens = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var booksTitles = context.BooksCategories.Where(x=>tokens.Contains(x.Category.Name.ToLower()))
                .OrderBy(x=>x.Book.Title)
                .Select(x=>x.Book.Title).ToArray();

            return string.Join("\n", booksTitles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        
                var books = context.Books.Where(x => x.ReleaseDate< parsedDate)
                    .OrderByDescending(x=>x.ReleaseDate)
                    .Select(x => new
                    {
                        x.Title,
                        x.EditionType,
                        x.Price
                    }).ToList();

                return string.Join("\n", books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:f2}"));  
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors.Where(x => x.FirstName.EndsWith(input))
                .Select(x => $"{x.FirstName} {x.LastName}").ToArray()
                .OrderBy(x => x);
            return string.Join("\n", authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books.Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title).ToArray();
            return string.Join("\n", titles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})");
            return string.Join("\n", books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Where(x => x.Title.Length > lengthCheck).Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    BooksCount = x.Books.Select(x => x.Copies).Sum()
                }).ToArray().OrderByDescending(x => x.BooksCount)
                .Select(x => $"{x.Name} - {x.BooksCount}");
            return string.Join("\n", authors);
        }

        public static string GetTotalProfitByCategory2(BookShopContext context)
        {
            var categories = context.BooksCategories.GroupBy(x => x.Category.Name)
                .Select(x => new
                {
                    Category = x.Key,
                    Profit = x.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x=>x.Category)
                .Select(x => $"{x.Category} ${x.Profit:f2}").ToArray();
            return string.Join("\n", categories);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new();
            var categories = context.Categories.OrderBy(x => x.Name)
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                        .OrderByDescending(x => x.Book.ReleaseDate)
                        .Select(x => new
                        {
                            x.Book.Title,
                            x.Book.ReleaseDate,
                        })
                        .Take(3)
                }).ToArray();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.ToString("yyyy")})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToArray();
            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();

            //int booksupdate = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010)
            //    .Update(x=> new Book() {Price = x.Price+5});
            //Console.WriteLine(booksupdate);

        }
        public static int RemoveBooks(BookShopContext context)
        {
            return context.Books.Where(x => x.Copies < 4200).Delete();
        }

    }
}


