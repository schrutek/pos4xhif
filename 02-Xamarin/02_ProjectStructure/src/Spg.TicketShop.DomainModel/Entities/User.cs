using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class User : EntityBase
    {
        public DateTime RegisterDateTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EMail { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string Role { get; set; }

        public virtual List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
