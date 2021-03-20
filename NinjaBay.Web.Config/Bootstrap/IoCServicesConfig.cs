using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NinjaBay.Data;
using NinjaBay.Data.Repositories;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Domain.Contracts.Services;
using NinjaBay.Domain.Services;
using NinjaBay.Domain.Validators.Product;
using NinjaBay.Infra;
using NinjaBay.Logging;
using NinjaBay.Shared.Configs;
using NinjaBay.Shared.Infra;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Web.Config.Bootstrap
{
    public static class IoCServicesConfig
    {
        public static IServiceCollection AppAddIoCServices(this IServiceCollection services, IConfiguration config)
        {
            //options/config
            ConfigureOptions(services, config);

            //Infra
            AppLoggerFactory.Initialize(new AppLogger(), config.GetConnectionString("Connection"));

            services.AddSingleton(AppLoggerFactory.GetLogger());
            services.AddSingleton<IAppHttpClient, AppHttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ILoggedUser, LoggedUser>();

            //events
            services.AddScoped<IDomainNotification, DomainNotification>();


            //services
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();

            //validators
            services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);

            //persistence

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            typeof(UserRepository).Assembly.GetTypes().Where(x =>
                    x.FullName.Contains("Repositories") && x.GetInterfaces().Any() && x.IsClass &&
                    x != typeof(Repository<>))
                .ToList().ForEach(x =>
                {
                    var @interface = x.GetInterfaces().FirstOrDefault(s => s.Name.Contains(x.Name));

                    if (@interface == null) return;

                    services.AddScoped(@interface, x);
                });

            return services;
        }

        private static void ConfigureOptions(IServiceCollection services, IConfiguration config)
        {
            var appConfig = new AppConfig();

            config.Bind(nameof(AppConfig), appConfig);

            appConfig.ConnectionString = config.GetConnectionString("Connection");

            services.AddSingleton(appConfig);
        }
    }
}