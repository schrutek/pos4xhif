using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class Event : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Show> Shows { get; set; } = new List<Show>();
    }
}
