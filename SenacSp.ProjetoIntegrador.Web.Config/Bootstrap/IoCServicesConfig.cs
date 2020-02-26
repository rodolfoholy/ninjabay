using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SenacSp.ProjetoIntegrador.Logging;
using SenacSp.ProjetoIntegrador.Shared.Infra;
using SenacSp.ProjetoIntegrador.Infra;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Infra;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Services;
using SenacSp.ProjetoIntegrador.Domain.Services;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using SenacSp.ProjetoIntegrador.Data;
using SenacSp.ProjetoIntegrador.Data.Repositories;
using SenacSp.ProjetoIntegrador.Shared.Configs;
using SenacSp.ProjetoIntegrador.Domain.Validators;

namespace SenacSp.ProjetoIntegrador.Web.Config.Bootstrap
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