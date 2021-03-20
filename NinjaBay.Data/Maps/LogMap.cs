using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Maps
{
    internal class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("logs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.OccurredAt)
                .HasColumnName("occurred_at")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.Level)
                .HasColumnName("level")
                .HasColumnType("varchar(255)");

            builder.Property(t => t.Logger)
                .HasColumnName("logger")
                .HasColumnType("varchar(255)");

            builder.Property(t => t.Message)
                .HasColumnName("message")
                .HasColumnType("text");

            builder.Property(t => t.Exception)
                .HasColumnName("exception")
                .HasColumnType("text");
        }
    }
}