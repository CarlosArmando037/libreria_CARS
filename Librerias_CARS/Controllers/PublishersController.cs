﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Librerias_CARS.Data.Services;
using Librerias_CARS.Data.ViewModels;
using System;
using Librerias_CARS.Exceptions;

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
            try
            {
                var newPublisher = _publishersServices.AddPublishers(publisher);
                return Created(nameof(AddPublisher), newPublisher);

            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, nombre de le editoria: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersServices.GetPublisherByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisher(int id)
        {
            var _response = _publishersServices.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersServices.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
