using Microsoft.EntityFrameworkCore;
using Spg.TicketShop.DomainModel.Entities;
using Spg.TicketShop.DomainModel.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel
{
    public class RepositoryContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Show> Shows { get; set; }

        public virtual DbSet<Contingent> Contingents { get; set; }

        public virtual DbSet<Price> Prices { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ShowConfiguration());
            modelBuilder.ApplyConfiguration(new ContingentConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PriceConfiguration());
        }
    }
}