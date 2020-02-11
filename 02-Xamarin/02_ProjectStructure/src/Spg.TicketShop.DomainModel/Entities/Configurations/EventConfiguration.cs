using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("EventId").IsRequired();
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();

            builder.HasMany(c => c.Shows).WithOne(c => c.Event).HasForeignKey(c => c.EventId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Event() { Id = new Guid("2ba2c35d-f5f1-42ae-b339-61f2a7518724"), Name = "Was gibt es Neues", Description = "Beschreibung zu Was gibt es Neues" },
                new Event() { Id = new Guid("a6aac1b7-688f-4ee3-870b-99a9067e4549"), Name = "Wir sind Kaiser", Description = "Beschreibung zu Wir sind Kaiser" }
            );
        }
    }
}