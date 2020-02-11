using Spg.TicketShop.Services;
using System;

namespace Spg.TicketShop.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            UserService userService = new UserService(null, null);
        }
    }
}
