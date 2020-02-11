using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("UserId").IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Role).HasMaxLength(200).IsRequired();

            builder.HasMany(c => c.Bookings).WithOne(c => c.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new User() { Id = new Guid("bd5450a6-d559-4554-bf8a-4a147962d5e3"), RegisterDateTime = DateTime.Now, FirstName = "Martin", LastName = "Schrutek", EMail = "martin@schrutek.at", Role = "G", PasswordHash = "DQDXAS2biNLKwilA6iNB+hMRFTR+fhm83+iXmWzNrvc=", Salt = "DsheTX46so1pULQhvj3EmQ==" },
                new User() { Id = new Guid("7f3e6f22-a9a8-4bad-8255-efe7e4ccc28d"), RegisterDateTime = DateTime.Now, FirstName = "Hans", LastName = "Hofer", EMail = "hans@hofer.at", Role = "G", PasswordHash = "DQDXAS2biNLKwilA6iNB+hMRFTR+fhm83+iXmWzNrvc=", Salt = "DsheTX46so1pULQhvj3EmQ==" },
                new User() { Id = new Guid("aff66d0a-5f4d-4073-bc5e-fd3ddfc7a8a4"), RegisterDateTime = DateTime.Now, FirstName = "Martina", LastName = "Rautner", EMail = "martina@rautner.at", Role = "G", PasswordHash = "DQDXAS2biNLKwilA6iNB+hMRFTR+fhm83+iXmWzNrvc=", Salt = "DsheTX46so1pULQhvj3EmQ==" },
                new User() { Id = new Guid("4bd6c230-c96b-4fe7-b2c7-35729800917e"), RegisterDateTime = DateTime.Now, FirstName = "Stefanie", LastName = "Müller", EMail = "stefanie@mueller.at", Role = "G", PasswordHash = "DQDXAS2biNLKwilA6iNB+hMRFTR+fhm83+iXmWzNrvc=", Salt = "DsheTX46so1pULQhvj3EmQ==" }
            );
        }
    }
}
