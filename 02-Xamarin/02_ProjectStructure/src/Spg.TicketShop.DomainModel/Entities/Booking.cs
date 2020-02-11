using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class Booking : EntityBase
    {
        public Guid ContingentId { get; set; }

        public Guid UserId { get; set; }

        public DateTime BookingDateTime { get; set; }

        public int TicketCount { get; set; }

        public string TicketState { get; set; }

        public virtual Contingent Contingent { get; set; }

        public virtual User User { get; set; }
    }
}
