using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NinjaBay.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDataContext>
    {
        public ECommerceDataContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../NinjaBay.Web");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ECommerceDataContext>();
            var connectionString = configuration.GetConnectionString("Connection");
            builder.UseNpgsql(connectionString);
            return new ECommerceDataContext(builder.Options);
        }
    }
}