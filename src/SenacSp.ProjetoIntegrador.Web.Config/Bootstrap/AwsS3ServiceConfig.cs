using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Infra;
using SenacSp.ProjetoIntegrador.Infra;
using SenacSp.ProjetoIntegrador.Shared.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Web.Config.Bootstrap
{
    public static class AwsS3ServiceConfig
    {
        public static IServiceCollection AppAddAwsS3Service(this IServiceCollection services, IConfiguration config)
        {
            var awsConfig = new AwsS3Config();

            config.GetSection(nameof(AwsS3Config)).Bind(awsConfig);

            services.AddSingleton(awsConfig);

            services.AddSingleton<IAwsS3StorageService, AwsS3StorageService>();

            return services;
        }

    }
}
