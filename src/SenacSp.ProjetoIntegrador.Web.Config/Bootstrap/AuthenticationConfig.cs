using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Web.Config.Bootstrap
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AppAddAuthentication(this IServiceCollection services,
            IConfiguration config, IWebHostEnvironment env)

        {
            var jwtTokenConfig = new JwtTokenConfig();

            config.GetSection(nameof(JwtTokenConfig)).Bind(jwtTokenConfig);

            services.AddSingleton(jwtTokenConfig);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = jwtTokenConfig.TokenValidationParameters;
                x.RequireHttpsMetadata = !env.IsDevelopment();
            });

            return services;
        }
    }
}
