using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books) 
        {
            Books = books.ToList();
        }

        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class LibraryIterator : IEnumerator<Book>
        {
            private int currentIndex = -1;
            
            private List<Book> books;

            public LibraryIterator(List<Book> books)
            {
               this.books = books;
                books.Sort();
            }
            
            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
             return ++currentIndex< books.Count;
            }

            public void Reset()
            {
               currentIndex = -1;
            }
            public void Dispose()
            {

            }
        }
    }
}
