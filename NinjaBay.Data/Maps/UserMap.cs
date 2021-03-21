using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaBay.Domain.Contracts.Services;
using NinjaBay.Domain.Entities;
using NinjaBay.Shared.Enums;

namespace NinjaBay.Data.Maps
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        private readonly IPasswordHasherService _passwordHasherService;

        public UserMap(IPasswordHasherService passwordHasherService)
        {
            _passwordHasherService = passwordHasherService;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("Varchar(255)")
                .IsRequired();

            builder.HasIndex(x => x.Email)
                .IsUnique();

            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .HasColumnType("Varchar(255)")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("name")
                .HasColumnType("Varchar(255)")
                .IsRequired();

            builder.HasIndex(x => x.Senha)
                .IsUnique();

            builder.Property(x => x.Active)
                .HasColumnName("active")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .HasColumnType("varchar(100)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}