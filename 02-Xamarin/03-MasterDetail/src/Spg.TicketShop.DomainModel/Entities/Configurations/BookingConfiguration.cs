using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("BookingId").IsRequired();

            builder.HasData(
                new Booking() { Id = new Guid("dc9f2386-c257-4178-9a77-608e6672811e"), BookingDateTime = DateTime.Now, ContingentId = new Guid("2c925f81-56ec-43eb-b3ed-7beeaa06aad6"), UserId = new Guid("bd5450a6-d559-4554-bf8a-4a147962d5e3"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("a1b32352-84e7-4a6e-b574-33750fffcf8d"), BookingDateTime = DateTime.Now, ContingentId = new Guid("2c925f81-56ec-43eb-b3ed-7beeaa06aad6"), UserId = new Guid("bd5450a6-d559-4554-bf8a-4a147962d5e3"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("800d50be-8320-4d2f-a43c-2dd7d2d53673"), BookingDateTime = DateTime.Now, ContingentId = new Guid("2c925f81-56ec-43eb-b3ed-7beeaa06aad6"), UserId = new Guid("bd5450a6-d559-4554-bf8a-4a147962d5e3"), TicketState = "S", TicketCount = 2 },
                new Booking() { Id = new Guid("d9e7d295-2a3e-47e0-9bf0-cddde77c5cf9"), BookingDateTime = DateTime.Now, ContingentId = new Guid("086b12a7-9c2c-41bb-9328-326196c82b73"), UserId = new Guid("bd5450a6-d559-4554-bf8a-4a147962d5e3"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("0bba6eae-4b62-4ed9-9440-298f89e3feea"), BookingDateTime = DateTime.Now, ContingentId = new Guid("2d760766-3b22-4675-892b-d537374a5d5c"), UserId = new Guid("7f3e6f22-a9a8-4bad-8255-efe7e4ccc28d"), TicketState = "S", TicketCount = 3 },
                new Booking() { Id = new Guid("56318d01-758d-4994-b3a7-056f07f4c18f"), BookingDateTime = DateTime.Now, ContingentId = new Guid("2d760766-3b22-4675-892b-d537374a5d5c"), UserId = new Guid("7f3e6f22-a9a8-4bad-8255-efe7e4ccc28d"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("6446ec8f-4bac-45e5-b53b-3cbc4fda5b39"), BookingDateTime = DateTime.Now, ContingentId = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f"), UserId = new Guid("7f3e6f22-a9a8-4bad-8255-efe7e4ccc28d"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("25f3b064-7fae-44d7-ad8a-bae54fd2dbd8"), BookingDateTime = DateTime.Now, ContingentId = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f"), UserId = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), TicketState = "S", TicketCount = 2 },
                new Booking() { Id = new Guid("c83a6573-72ff-4fde-a0be-dcec81468660"), BookingDateTime = DateTime.Now, ContingentId = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f"), UserId = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), TicketState = "S", TicketCount = 4 },
                new Booking() { Id = new Guid("e21d3f90-a0f5-4fd0-ac4b-bba2fd80ca5d"), BookingDateTime = DateTime.Now, ContingentId = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f"), UserId = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), TicketState = "S", TicketCount = 1 },
                new Booking() { Id = new Guid("2f5aaf6c-e7db-4b11-be4c-19b5bac45c04"), BookingDateTime = DateTime.Now, ContingentId = new Guid("e3db7386-70b9-40c7-a169-f7268942a358"), UserId = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), TicketState = "S", TicketCount = 5 },
                new Booking() { Id = new Guid("977b356e-5992-4154-87ef-823378852e61"), BookingDateTime = DateTime.Now, ContingentId = new Guid("e3db7386-70b9-40c7-a169-f7268942a358"), UserId = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), TicketState = "S", TicketCount = 3 }
            );
        }
    }
}
