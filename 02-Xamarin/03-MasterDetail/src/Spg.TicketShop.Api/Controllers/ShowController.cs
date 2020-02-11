using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.TicketShop.Api.Services;
using Spg.TicketShop.Core.Eceptions;

namespace Spg.TicketShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly ShowService _eventService;

        public ShowController(ShowService eventService)
        {
            _eventService = eventService;
        }

        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAllShows()
        {
            try
            {
                return Ok(_eventService.GetAllShows());
            }
            catch (ServiceException)
            {
                //TODO: Exception-Logging/Tracing
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetShowsByEvent(string id)
        {
            try
            {
                return Ok(_eventService.GetShowsByEvent(new Guid(id)));
            }
            catch (ServiceException)
            {
                //TODO: Exception-Logging/Tracing
                return BadRequest();
            }
        }
    }
}