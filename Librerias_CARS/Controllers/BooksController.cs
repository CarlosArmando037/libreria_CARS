using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Librerias_CARS.Data.Services;
using Librerias_CARS.Data.ViewModels;
using System.Collections.Generic;
using Librerias_CARS.Data.Models;
using System.ComponentModel;

namespace Librerias_CARS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        //listar Libros
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBks();
            return Ok(allbooks);

        }
        //listar libro por ID
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        //añadir libro
        [HttpPost("add-book-With-Authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("Update-Book-By-Id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("Delete-Book-By-Id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
        

        

    }
}
