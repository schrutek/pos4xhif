using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SPG.CodeFirstApplication.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPG.CodeFirstApplication.Configurations
{
    public class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.ToTable("SchoolClasses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();
            builder.Property(c => c.Department).HasMaxLength(250).IsRequired();

            builder.HasMany(c => c.Pupils).WithOne(c => c.SchoolClass).HasForeignKey(c => c.SchoolClassId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SchoolClass() { Id = new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee"), Name = "3AHIF", Department = "Höhere Informatik" },
                new SchoolClass() { Id = new Guid("ac87ce7b-89bd-434f-a800-b2979d745c1b"), Name = "3BHIF", Department = "Höhere Informatik" },
                new SchoolClass() { Id = new Guid("1712daf8-bf01-4f88-905b-74ec9498d077"), Name = "4AHIF", Department = "Höhere Informatik" }
                );
        }
    }
}