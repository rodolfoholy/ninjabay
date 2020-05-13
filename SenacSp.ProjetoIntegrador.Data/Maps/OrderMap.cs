using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Data.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();
            builder.Property(x => x.OrderIdentifier)
                .ValueGeneratedOnAdd();
            
            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp")
                .IsRequired();
            
            builder.HasOne(x => x.Shopper)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShopperId);

            builder.HasOne(x => x.ShippingAddress)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShippingAddressId);
            
            builder.Property(x => x.PaymentStatus)
                .HasColumnName("payment_status")
                .HasColumnType("varchar(100)")
                .HasConversion<string>()
                .IsRequired();
            
            builder.Property(x => x.PaymentMethod)
                .HasColumnName("payment_method")
                .HasColumnType("varchar(100)")
                .HasConversion<string>()
                .IsRequired();
            
            builder.Property(x => x.Total)
                .HasColumnName("price")
                .HasColumnType("numeric");
            
        }
    }
}