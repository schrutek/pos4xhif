using Spg.TicketShop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spg.TicketShop.Core.Services
{
    /// <summary>
    /// Hier werden die angeboteten Serviceses der REST Schnittstelle auf C# Methoden abgebildet.
    /// Vererbung ist die einfachste Methode um dies zu realisieren. Eine alternative wäre
    /// Dependency Injection.
    /// </summary>
    /// <remarks>
    /// Die Methode um auf den REST-Service zuzugreifen ist in der Basisklasse implementiert. 
    /// Diese wird, sozusagen nur noch um die für die Applikation notwendigen CRUD-Methoden erweitert.
    /// </remarks>
    public class CrudBase : RestServiceBase
    {
        /// <summary>
        /// Ruft die REST-Api auf und gibt alle Events zurück. (URL= http://.../event/all)
        /// Es wird der EventController aufgerufen
        /// </summary>
        /// <returns>Eine Liste von EventDto's</returns>
        public Task<IEnumerable<EventDto>> GetAllEventsAsync() => SendAsync<IEnumerable<EventDto>>(HttpMethod.Get, "event/all");

        /// <summary>
        /// Ruft die REST-Api auf und gibt ein Event zurück. (URL= http://.../event/{GUID})
        /// Es wird der EventController aufgerufen
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>Ein EventDto, welches der angegebenen eventId entspricht</returns>
        public Task<EventDto> GetEventsByEventAsync(Guid eventId) => SendAsync<EventDto>(HttpMethod.Get, "event", eventId.ToString());

        /// <summary>
        /// Ruft die REST-Api auf und gibt alle Shows zurück. (URL= http://.../show/all)
        /// Es wird der ShowController aufgerufen
        /// </summary>
        /// <returns>Eine Liste von ShowDto's</returns>
        public Task<IEnumerable<ShowDto>> GetAllShowsAsync() => SendAsync<IEnumerable<ShowDto>>(HttpMethod.Get, "show/all");

        /// <summary>
        /// Ruft die REST-Api auf und gibt eine Show zurück. (URL= http://.../show/{GUID})
        /// Es wird der ShowController aufgerufen
        /// </summary>
        /// <param name="eventId">Eine Liste von ShowDto's, eingeschränkt auf die Event-Id</param>
        /// <returns></returns>
        public Task<IEnumerable<ShowDto>> GetShowsByEventAsync(Guid eventId) => SendAsync<IEnumerable<ShowDto>>(HttpMethod.Get, "show", eventId.ToString());

        //TODO: Implementierung aller restlichen Methoden um Daten vom REST-Service zu holen oder zu senden. (GET, PUP, POST, DELETE)
        //...
    }
}
