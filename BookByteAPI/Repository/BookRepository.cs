using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookByteAPI.Models;

namespace BookByteAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext bookContext;

        public BookRepository(BooksContext bookContext)
        {
            this.bookContext = bookContext;
        }

        public bool Create(Book book)
        {
            bool success;

            try
            {
                bookContext.Books.Add(book);
                bookContext.SaveChanges();
                success = true;
            }
            catch
            {
                success = false;
            }

            return success;
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> books = bookContext.Books.ToList();
            return books;
        }

        public Book GetBook(int id)
        {
            Book book = bookContext.Books.FirstOrDefault(i => i.Id == id);
            return book;
        }
    }
}
