using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Librerias_CARS.Data.Services;
using Librerias_CARS.Data.ViewModels;

namespace Librerias_CARS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //minuto 09:06
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsServices;

        public AuthorsController(AuthorsService authorsServices)
        {
            _authorsServices = authorsServices;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _authorsServices.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}
