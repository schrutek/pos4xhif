using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities
{
    public class Price : EntityBase
    {
        public string PriceDescription { get; set; }

        public double PriceGross { get; set; }

        public Guid ContingentId { get; set; }

        public virtual Contingent Contingent { get; set; }
    }
}
