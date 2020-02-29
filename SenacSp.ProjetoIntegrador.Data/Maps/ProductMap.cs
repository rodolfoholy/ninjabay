using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("Varchar(255)")
                .IsRequired();
            builder.Property(x => x.Description)
                .HasColumnName("desciption")
                .HasColumnType("Varchar(255)");

            builder.Property(x => x.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int");

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasColumnType("numeric");

        }
    }
}
