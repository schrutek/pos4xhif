using Microsoft.Extensions.Configuration;
using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.DomainModel;
using Spg.TicketShop.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spg.TicketShop.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EventService
    {
        private readonly RepositoryContext _db;
        private readonly IConfiguration _configuration;

        public EventService(RepositoryContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _db = context;
        }

        /// <summary>
        /// Liefert mittels LinQ-Statement alle Events zurück.
        /// </summary>
        /// <returns>Liste der Events</returns>
        public IEnumerable<EventDto> GetAllEvents()
        {
            return _db.Events.ToList().Select(c => new EventDto()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });
        }

        /// <summary>
        /// Liefert ein Event anhand de parameters zurück. (LinQ-Statement)
        /// </summary>
        /// <param name="eventId">Die ID des Events</param>
        /// <returns>Den gefundenen Datensatz</returns>
        public EventDto GetEventByEvent(Guid eventId)
        {
            return _db.Events.Where(c => c.Id  == eventId).Select(c => new EventDto()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).SingleOrDefault();
        }
    }
}
