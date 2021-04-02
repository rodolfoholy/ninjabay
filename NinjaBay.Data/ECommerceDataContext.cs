using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NinjaBay.Data.Maps;

namespace NinjaBay.Data
{
    public class ECommerceDataContext : DbContext
    {
        public ECommerceDataContext(DbContextOptions<ECommerceDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ninja_bay");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogMap).GetTypeInfo().Assembly);
        }

        private static DbContextOptions<ECommerceDataContext> Options(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<ECommerceDataContext>();
            builder.UseNpgsql(connectionString);
            return builder.Options;
        }

        public static ECommerceDataContext Instance(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<ECommerceDataContext>();
            builder.UseNpgsql(connectionString);
            return new ECommerceDataContext(builder.Options);
        }
    }
}
