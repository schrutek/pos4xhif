using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spg.TicketShop.Api.Services;
using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.Core.Eceptions;

namespace Spg.TicketShop.Api.Controllers
{
    /// <summary>
    /// Die Controller-Klasse, die sich um die Events kümmert.
    /// Idealerweise kümmert sich die Klasse ausschließlich um Events. Es werden
    /// also nur Event Daten zurückgegeben, keine anderen! Dies hat natürlich 
    /// zur Folge, dass in einr großen Applikation, viele, viele Controller-Klassen
    /// existieren.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // private Field, welches die Service-Instanz beinhaltet.
        private readonly EventService _eventService;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <remarks>
        /// Um die Daten aus der DB zu halten wird die Klasse <code>EventService</code> verwendet.
        /// </remarks>
        /// <param name="eventService">
        /// Wird über Dependency Injection durch services.AddScoped() in ConfigureServices() übergeben.
        /// Siehe <see cref="Spg.TicketShop.Api.Extensions.HostingExtensions"/>.
        /// </param>
        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Diese Methode liefert alle Events aus der Datenbank an den Aufrufer zurück.
        /// Der Aufrufer kann eine Web-Site oder eine andere Applikation sein.
        /// </summary>
        /// <remarks>
        /// Um die Daten aus der DB zu halten wird die Klasse <code>EventService</code> verwendet.
        /// </remarks>
        /// <returns>
        /// Einen JSON-String mit allen Daten (.Net serialisiert das automatisch als JSON)
        /// </returns>
        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAllEvents()
        {
            try
            {
                return Ok(_eventService.GetAllEvents());
            }
            catch (ServiceException)
            {
                //TODO: Exception-Logging/Tracing
                return BadRequest();
            }
        }

        /// <summary>
        /// Diese Methode liefert nur ein Event mit der im Parameteer angegebenen ID
        /// an den Aufrufer zurück. Die ID's sind in der gesamten DB, GUID's. 
        /// (Global Unique IDentifier)
        /// </summary>
        /// <param name="id">
        /// Die ID (GUID) die angibt, welcher Datensatz aus der DB zurückgegeben werden soll.
        /// </param>
        /// <returns>
        /// Einen JSON-String mit dem gefundenen Datensatz (.Net serialisiert das automatisch als JSON)
        /// </returns>
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetEventByEvent(string id)
        {
            try
            {
                return Ok(_eventService.GetEventByEvent(new Guid(id)));
            }
            catch (ServiceException)
            {
                //TODO: Exception-Logging/Tracing
                return BadRequest();
            }
        }

        // HttpGet: Events by Name, ..by Date, ..by...
        // HttpPut:
        // HttpPost:
        // Http:Delete:
    }
}