using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Data.Maps
{
    public class ShopperMap : IEntityTypeConfiguration<Shopper>
    {
        public void Configure(EntityTypeBuilder<Shopper> builder)
        {
            builder.ToTable("shoppers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();
            
            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Shopper>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

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
            
            builder.OwnsOne(x => x.Cpf, b =>
            {
                b.Property(x => x.Number)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Identification_Number");

                b.Property(x => x.Type)
                    .HasColumnName("Identification_Type")
                    .HasConversion<string>()
                    .HasColumnType("varchar(100)");
                b.HasIndex(x => x.Number)
                    .IsUnique();
            });
        }
    }
}