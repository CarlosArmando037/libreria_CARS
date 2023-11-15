using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Librerias_CARS.Data.Services;
using Librerias_CARS.Data.ViewModels;

namespace Librerias_CARS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersServices;

        public PublishersController(PublishersService publishersServices)
        {
            _publishersServices = publishersServices;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersServices.AddPublishers(publisher);
            return Ok();
        }
        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisher(int id)
        {
            var _response = _publishersServices.GetPublisherData(id);
            return Ok(_response);
        }

    }
}
