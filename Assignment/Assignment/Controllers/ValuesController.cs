using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Assignment1;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<Book> books = new List<Book>()
        {
            new Book("Harry Potter", "J.K. Rowling",600,"HP00000000000"),
            new Book("The Great Gatsby", "F. Scott Fitzgerald",600,"TGG0000000000"),
            new Book("Moby Dick", "J.K. Rowling",600,"MD00000000000"),
        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET api/values/5
        [HttpGet("{isbn13}")]
        public ActionResult<Book> Get(string isbn13)
        {

            foreach (var book in books)
            {
                if (isbn13 == book.Isbn13)
                {
                    return book;
                }
            }

            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Book b)
        {
            books.Add(b);
        }

        // PUT api/values/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Book b)
        {
            foreach (var book in books)
            {
                if (isbn13 == book.Isbn13)
                {
                    book.Title = b.Title;
                    book.Author = b.Author;
                    book.PageNumber = b.PageNumber;
                    book.Isbn13 = b.Isbn13;
                }
            }
        }

        // DELETE api/values/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            Book b = null;
            foreach (var book in books)
            {
                if (isbn13 == book.Isbn13)
                {
                    b = book;
                }
            }

            if (b != null)
            {
                books.Remove(b);
            }
        }
    }
}
