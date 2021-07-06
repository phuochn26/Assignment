  
using System.Collections.Generic;
using RBE2.Models;
using RBE2.Services;
using Microsoft.AspNetCore.Mvc;

namespace RBE2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public List<Author> List()
        {
            return _authorService.GetList();
        }
        [HttpPost]
        public Author Create(Author author)
        {
            _authorService.Create(author);
            return author;
        }
        [HttpPut("id")]
        public IActionResult Update(int id,Author author)
        {
            if(id == 0)
            {
                return StatusCode(404);
            }
            else
            {
                _authorService.Update(author);
            }
            return StatusCode(200);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            
            _authorService.Delete(id);
            return StatusCode(200);
        }
    }
}