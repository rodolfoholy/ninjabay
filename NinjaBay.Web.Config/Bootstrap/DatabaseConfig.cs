﻿using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NinjaBay.Data;

namespace NinjaBay.Web.Config.Bootstrap
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AppAddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            
            var uri = new Uri(Environment.GetEnvironmentVariable("DATABASE_URL"));
            var username = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            string connectionString = 
               "; Database=" + uri.AbsolutePath.Substring(1) +
               "; Username=" + username +
               "; Password=" + password + 
               "; Port=" + uri.Port +
               "; SSL Mode=Require; Trust Server Certificate=true;";
            
            
            services.AddDbContextPool<ECommerceDataContext>(options =>
            {
                options.UseNpgsql(connectionString);
                // options.UseNpgsql(configuration.GetConnectionString("Connection"));
                options.EnableSensitiveDataLogging();
            });

            return services;
        }

        public static IApplicationBuilder AppUseMigrations(this IApplicationBuilder app, IConfiguration config,
            IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ECommerceDataContext>();

                if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
            }

            return app;
        }
    }
}
