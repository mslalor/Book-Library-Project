using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models; 

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public List<Book> Get()
        {
            List<Book> book = BookUtility.GetBook();
            return book;
        }

        // [HttpGet("{id}", Name = "Get")]
        // public Book Get(int id)
        // {
        //     Book newBook= BookUtility.GetBookById(id);
        //     return newBook;
        // }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            BookUtility.AddBook(book);
        }
/*
        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id)
        {
            BookUtility.HoldBook(id);
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BookUtility.DeleteBook(id);
        }*/
    }
}