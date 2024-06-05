using IteratorsAndComparators;
List<Book> books = new();

Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
Book bookTwo = new Book("The Documents in the Case", 2002,
    "Dorothy Sayers", "Robert Eustace");
Book bookThree = new Book("The Documents in the Case", 1930);

books.Add(bookOne);
books.Add(bookTwo);
books.Add(bookThree);

Library libraryOne = new Library();
Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

foreach (var book in libraryTwo)
{
    Console.WriteLine(book);
}

