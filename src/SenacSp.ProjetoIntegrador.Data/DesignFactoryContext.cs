using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SenacSp.ProjetoIntegrador.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDataContext>
    {
        public ECommerceDataContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../SenacSp.ProjetoIntegrador.Web");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ECommerceDataContext>();
            var connectionString = configuration.GetConnectionString("Connection");
            builder.UseNpgsql(connectionString);
            Console.WriteLine(connectionString);
            return new ECommerceDataContext(builder.Options);
        }
    }
}
