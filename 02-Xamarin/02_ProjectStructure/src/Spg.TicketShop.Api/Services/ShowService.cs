using Microsoft.Extensions.Configuration;
using Spg.TicketShop.Core.Dtos;
using Spg.TicketShop.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spg.TicketShop.Api.Services
{
    public class ShowService
    {
        private readonly RepositoryContext _db;
        private readonly IConfiguration _configuration;

        public ShowService(RepositoryContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _db = context;
        }

        public IEnumerable<ShowDto> GetAllShows()
        {
            return _db.Shows.ToList().Select(c => new ShowDto()
            {
                Id = c.Id,
                CheckIn = c.CheckIn,
                Start = c.Start,
                End = c.End,
                EventId = c.EventId
            });
        }

        public IEnumerable<ShowDto> GetShowsByEvent(Guid eventId)
        {
            return _db.Shows.Where(c => c.EventId == eventId).ToList().Select(c => new ShowDto()
            {
                Id = c.Id,
                CheckIn = c.CheckIn,
                Start = c.Start,
                End = c.End,
                EventId = c.EventId
            });
        }
    }
}
