using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Maps
{
    public class ShopperAddressMap : IEntityTypeConfiguration<ShopperAddress>
    {
        public void Configure(EntityTypeBuilder<ShopperAddress> builder)
        {
            builder.ToTable("shopper_addresses");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(100)")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("Varchar(255)")
                .IsRequired();

            builder.HasOne(x => x.Shopper)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.ShopperId);

            builder.OwnsOne(x => x.Address, b =>
            {
                b.Property(x => x.PlaceName)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("addres_information_place_name");

                b.Property(x => x.Number)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("addres_information_number");

                b.Property(x => x.Complement)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("addres_information_complement");

                b.Property(x => x.District)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("addres_information_district");

                b.Property(x => x.ZipCode)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("addres_information_zipcode");

                b.Property(x => x.City)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("addres_information_city");

                b.Property(x => x.State)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("addres_information_state");
            });
        }
    }
}