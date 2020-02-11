using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.Core.Dtos
{
    public class UserDto
    {
        public string EMail { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }
    }
}
