using Microsoft.EntityFrameworkCore;
using SenacSp.ProjetoIntegrador.Data.Maps;
using System.Reflection;

namespace SenacSp.ProjetoIntegrador.Data
{
    public class ECommerceDataContext : DbContext
    {
        public ECommerceDataContext(DbContextOptions<ECommerceDataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("senac_ecommerce");
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
