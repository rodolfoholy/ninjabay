using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NinjaBay.Domain.CommandHandlers;
using NinjaBay.Web.Config.PipeLines;

namespace NinjaBay.Web.Config.Bootstrap
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