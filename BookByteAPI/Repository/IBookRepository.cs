using BookByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookByteAPI.Repository
{
    public interface IBookRepository
    {
        bool Create(Book book);
        IEnumerable<Book> GetAll();
        Book GetBook(int id);
    }
}
