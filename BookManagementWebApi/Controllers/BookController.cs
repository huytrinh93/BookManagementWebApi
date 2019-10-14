using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookManagementWebApi.Models;

namespace BookManagementWebApi.Controllers
{
    public class BookController : ApiController
    {
        private IManagementContext db = new BookManagementContext();

        // Add constructors
        public BookController() { }

        public BookController(IManagementContext context)
        {
            db = context;
        }

        private Book[] books = new Book[]
        {
            new Book { Id = 1, title = "The Elephant Tree (Paperback)", author = "R.D. Ronald", releaseDate = DateTime.Now, Price = 1.99},
            new Book { Id = 2, title = "Harry Potter and the Sorcerer's Stone", author = "J.K. Rowling", releaseDate = DateTime.Now, Price = 2.99},
            new Book { Id = 3, title = "The Woman in the Window", author = "A.J. Finn", releaseDate = DateTime.Now, Price = 5.99},
            new Book { Id = 4, title = "Finding Hope in the Darkness of Grief: Spiritual Insights Expressed Through Art, Poetry and Prose", author = "Diamante Lavendar", releaseDate = DateTime.Now, Price = 6.99},
            new Book { Id = 5, title = "Divergent", author = "Veronica Roth", releaseDate = DateTime.Now, Price = 9.99}
        };

        // GET: api/Books
        [ResponseType(typeof(IEnumerable<Book>))]
        public IEnumerable<Book> GetBooks()
        {
            return books;
        }

        // GET: api/Book/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = books.FirstOrDefault((b)=> b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}