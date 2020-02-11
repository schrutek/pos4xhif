using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spg.TicketShop.DomainModel.Entities.Configurations
{
    public class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.ToTable("Prices");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("PriceId").IsRequired();
            builder.Property(c => c.PriceDescription).HasMaxLength(200).IsRequired();

            builder.HasData(
                new Price() { Id = new Guid("fd32e407-3f04-4c6f-8a04-f3c30c491540"), PriceDescription = "Normalpreis", PriceGross = 10.90, ContingentId = new Guid("2c925f81-56ec-43eb-b3ed-7beeaa06aad6") },
                new Price() { Id = new Guid("091c4b22-0164-4b00-8421-cf7153f9a1a7"), PriceDescription = "Normalpreis", PriceGross = 20.90, ContingentId = new Guid("086b12a7-9c2c-41bb-9328-326196c82b73") },
                new Price() { Id = new Guid("d7978a10-d8ff-46a3-bf48-76a99cbd95a3"), PriceDescription = "Normalpreis", PriceGross = 12.50, ContingentId = new Guid("2d760766-3b22-4675-892b-d537374a5d5c") },
                new Price() { Id = new Guid("7ffbf1a5-88da-4a72-ab40-283713ff5698"), PriceDescription = "Normalpreis", PriceGross = 15.25, ContingentId = new Guid("8110cd6a-8cfc-4cc1-bfbf-86fee5d2636f") },
                new Price() { Id = new Guid("aa799e38-c752-4c3a-8910-aac296bc9898"), PriceDescription = "Normalpreis", PriceGross = 17.90, ContingentId = new Guid("e3db7386-70b9-40c7-a169-f7268942a358") },
                new Price() { Id = new Guid("b11133af-f8d2-438c-b2bb-e7a37ba246ad"), PriceDescription = "Normalpreis", PriceGross = 23.25, ContingentId = new Guid("457f09cd-17a6-4fe5-a3c3-670c43b19aa9") },
                new Price() { Id = new Guid("cb45bbfb-77ee-421b-9c63-6bdc9f36b66d"), PriceDescription = "Normalpreis", PriceGross = 8.25, ContingentId = new Guid("c44298ba-cea1-4449-98d2-4d710fa147c6") },
                new Price() { Id = new Guid("f1cf9a7b-fd94-4954-b97d-7fb7e0a06cc0"), PriceDescription = "Normalpreis", PriceGross = 9.50, ContingentId = new Guid("25a7fa20-80fd-4459-af65-07e35b25f2b8") },
                new Price() { Id = new Guid("b3eb0eb1-ebb8-4124-ba3a-d978c030fa49"), PriceDescription = "Ermäßigt", PriceGross = 21.25, ContingentId = new Guid("25a7fa20-80fd-4459-af65-07e35b25f2b8") }
            );
        }
    }
}
