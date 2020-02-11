using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime? LastChangeDate { get; set; }

        public virtual User LaseChangeUserId { get; set; }
    }
}
