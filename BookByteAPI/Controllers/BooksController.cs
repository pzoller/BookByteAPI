using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookByteAPI.Repository;
using BookByteAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookByteAPI.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        IBookRepository repository;

        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = repository.GetAll();
            return books;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBook")]
        public Book GetBook(int id)
        {
            Book book = repository.GetBook(id);
            return book;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Book book)
        {
            bool success = repository.Create(book);
            return CreatedAtRoute(MagicStrings.Contorllers.Books.RouteNames.GET_BOOK, new { id = book.Id }, book);
        }
    }
}
