using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Maps
{
    internal class ProductKeyWordMap : IEntityTypeConfiguration<ProductKeyWord>
    {
        public void Configure(EntityTypeBuilder<ProductKeyWord> builder)
        {
            builder.ToTable("product_key_words");

            builder.HasKey(x => new {x.ProductId, x.KeyWordId});

            builder.HasOne(x => x.Product)
                .WithMany(x => x.KeyWords)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(x => x.KeyWord)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.KeyWordId)
                .IsRequired();
        }
    }
}