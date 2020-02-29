using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Data.Maps
{
    internal class KeyWordMap : IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.ToTable("key_words");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.Word)
                .HasColumnName("word")
                .HasColumnType("varchar(255)");

            builder.HasIndex(x => x.Word)
                .IsUnique();
        }
    }
}
