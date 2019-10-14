using BookManagementWebApi.Controllers;
using BookManagementWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace BookManagementWebApi.Tests
{
    [TestClass]
    public class TestBookController
    {
        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var testBooks = GetTestBooks();
            var controller = new BookController();
            var result = controller.GetBooks() as IEnumerable<Book>;

            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks.Count, result.Count());
        }

        [TestMethod]
        public void GetBook_ShouldReturnCorrectBook()
        {
            var testBooks = GetTestBooks();
            var controller = new BookController();
            var result = controller.GetBook(4) as OkNegotiatedContentResult<Book>;

            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[3].title, result.Content.title);
        }

        [TestMethod]
        public void GetBook_ShouldNotFindProduct()
        {
            var controller = new BookController();
            var result = controller.GetBook(999);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Book> GetTestBooks()
        {
            var testBooks = new List<Book>();
            testBooks.Add(new Book { Id = 1, title = "The Elephant Tree (Paperback)", author = "R.D. Ronald", releaseDate = DateTime.Now, Price = 1.99 });
            testBooks.Add(new Book { Id = 2, title = "Harry Potter and the Sorcerer's Stone", author = "J.K. Rowling", releaseDate = DateTime.Now, Price = 2.99 });
            testBooks.Add(new Book { Id = 3, title = "The Woman in the Window", author = "A.J. Finn", releaseDate = DateTime.Now, Price = 5.99 });
            testBooks.Add(new Book { Id = 4, title = "Finding Hope in the Darkness of Grief: Spiritual Insights Expressed Through Art, Poetry and Prose", author = "Diamante Lavendar", releaseDate = DateTime.Now, Price = 6.99 });
            testBooks.Add(new Book { Id = 5, title = "Divergent", author = "Veronica Roth", releaseDate = DateTime.Now, Price = 9.99 });
            return testBooks;
        }
    }
}
