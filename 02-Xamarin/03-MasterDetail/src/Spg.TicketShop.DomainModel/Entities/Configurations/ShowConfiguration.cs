using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.ToTable("Shows");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ShowId").IsRequired();

            builder.HasMany(c => c.Contingents).WithOne(c => c.Show).HasForeignKey(c => c.ShowId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Show() { Id = new Guid("4644dfb6-99b3-4fd1-8d4e-e0a62d78b82c"), CheckIn = new DateTime(2021, 01, 20, 18, 00, 00), Start = new DateTime(2021, 01, 20, 19, 00, 00), End = new DateTime(2021, 01, 20, 21, 00, 00), EventId = new Guid("2ba2c35d-f5f1-42ae-b339-61f2a7518724") },
                new Show() { Id = new Guid("be71d341-b703-4a69-8c3b-312934afdced"), CheckIn = new DateTime(2021, 02, 20, 18, 00, 00), Start = new DateTime(2021, 02, 20, 19, 00, 00), End = new DateTime(2021, 02, 20, 21, 00, 00), EventId = new Guid("2ba2c35d-f5f1-42ae-b339-61f2a7518724") },
                new Show() { Id = new Guid("5ad74cfe-fb82-4f92-b37e-ccd38f679098"), CheckIn = new DateTime(2021, 03, 20, 18, 00, 00), Start = new DateTime(2021, 03, 20, 19, 00, 00), End = new DateTime(2021, 03, 20, 21, 00, 00), EventId = new Guid("a6aac1b7-688f-4ee3-870b-99a9067e4549") },
                new Show() { Id = new Guid("6473eed4-9ef2-4b71-8436-dbda9f1c570a"), CheckIn = new DateTime(2021, 04, 20, 18, 00, 00), Start = new DateTime(2021, 04, 20, 19, 00, 00), End = new DateTime(2021, 04, 20, 21, 00, 00), EventId = new Guid("a6aac1b7-688f-4ee3-870b-99a9067e4549") }
            );
        }
    }
}
