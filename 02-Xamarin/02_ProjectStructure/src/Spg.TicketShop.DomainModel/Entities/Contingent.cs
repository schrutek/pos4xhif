using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class Contingent : EntityBase
    {
        public string Name { get; set; }

        public int Seats { get; set; }

        public Guid ShowId { get; set; }

        public virtual List<Price> Prices { get; set; } = new List<Price>();

        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();

        public virtual Show Show { get; set; }
    }
}
