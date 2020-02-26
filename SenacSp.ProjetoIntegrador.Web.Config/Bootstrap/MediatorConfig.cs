using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SenacSp.ProjetoIntegrador.Domain.CommandHandlers;
using SenacSp.ProjetoIntegrador.Web.Config.PipeLines;
using System.Reflection;

namespace SenacSp.ProjetoIntegrador.Web.Config.Bootstrap
{
    public static class MediatorConfig
    {
        public static IServiceCollection AppAddMediator(this IServiceCollection services)

        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddMediatR(typeof(UserCommandHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}