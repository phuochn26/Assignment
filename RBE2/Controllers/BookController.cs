  
using System.Collections.Generic;
using RBE2.Models;
using RBE2.Services;
using Microsoft.AspNetCore.Mvc;

namespace RBE2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public List<Book> List()
        {
            return _bookService.GetList();
        }
        [HttpPost]
        public Book Create(Book book)
        {
            _bookService.Create(book);
            return book;
        }
        [HttpPut("id")]
        public IActionResult Update(int id,Book book)
        {
            if(id == 0)
            {
                return StatusCode(404);
            }
            else
            {
                _bookService.Update(book);
            }
            return StatusCode(200);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            
            _bookService.Delete(id);
            return StatusCode(200);
        }
    }
}