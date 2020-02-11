using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class Show : EntityBase
    {
        public DateTime CheckIn { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Guid EventId { get; set; }

        public virtual List<Contingent> Contingents { get; set; } = new List<Contingent>();

        public virtual Event Event { get; set; }
    }
}
