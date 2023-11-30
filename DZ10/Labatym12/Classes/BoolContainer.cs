using System.Linq;
using System.Collections.Generic;

namespace Library
{
    delegate string SortDelegate(Book book);
    static class BooksContainer
    {

        private static List<Book> booksList = new List<Book>();


        public static List<Book> BooksList
        {
            get
            {
                return booksList;
            }
        }



        public static void SortingListOfBooks(SortDelegate sortDelegate)
        {
            booksList = booksList.OrderBy(book => sortDelegate.Invoke(book)).ToList<Book>();
        }
        public static void AddBookToList(params Book[] booksArray)
        {
            foreach (Book book in booksArray)
            {
                booksList.Add(book);
            }
        }
    }
}