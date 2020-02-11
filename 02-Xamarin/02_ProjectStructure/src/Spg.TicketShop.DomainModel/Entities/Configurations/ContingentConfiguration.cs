using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class ContingentConfiguration : IEntityTypeConfiguration<Contingent>
    {
        public void Configure(EntityTypeBuilder<Contingent> builder)
        {
            builder.ToTable("Contingents");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("ContingentId").IsRequired();
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();

            builder.HasMany(c => c.Prices).WithOne(c => c.Contingent).HasForeignKey(c => c.ContingentId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Bookings).WithOne(c => c.Contingent).HasForeignKey(c => c.ContingentId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Contingent() { Id = new Guid("2c925f81-56ec-43eb-b3ed-7beeaa06aad6"), Name = "Parterre", Seats = 120, ShowId = new Guid("4644dfb6-99b3-4fd1-8d4e-e0a62d78b82c") },
                new Contingent() { Id = new Guid("086b12a7-9c2c-41bb-9328-326196c82b73"), Name = "Tribüne", Seats = 523, ShowId = new Guid("4644dfb6-99b3-4fd1-8d4e-e0a62d78b82c") },
                new Contingent() { Id = new Guid("2d760766-3b22-4675-892b-d537374a5d5c"), Name = "Parterre", Seats = 120, ShowId = new Guid("be71d341-b703-4a69-8c3b-312934afdced") },
                new Contingent() { Id = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f"), Name = "Tribüne", Seats = 893, ShowId = new Guid("be71d341-b703-4a69-8c3b-312934afdced") },
                new Contingent() { Id = new Guid("e3db7386-70b9-40c7-a169-f7268942a358"), Name = "Parterre", Seats = 125, ShowId = new Guid("5ad74cfe-fb82-4f92-b37e-ccd38f679098") },
                new Contingent() { Id = new Guid("457f09cd-17a6-4fe5-a3c3-670c43b19aa9"), Name = "Tribüne", Seats = 148, ShowId = new Guid("5ad74cfe-fb82-4f92-b37e-ccd38f679098") },
                new Contingent() { Id = new Guid("c44298ba-cea1-4449-98d2-4d710fa147c6"), Name = "Parterre", Seats = 963, ShowId = new Guid("6473eed4-9ef2-4b71-8436-dbda9f1c570a") },
                new Contingent() { Id = new Guid("25a7fa20-80fd-4459-af65-07e35b25f2b8"), Name = "Tribüne", Seats = 745, ShowId = new Guid("6473eed4-9ef2-4b71-8436-dbda9f1c570a") }
            );
        }
    }
}
