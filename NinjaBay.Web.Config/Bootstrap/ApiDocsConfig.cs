using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using NinjaBay.Shared.Utils;

namespace NinjaBay.Web.Config.Bootstrap
{
    public static class ApiDocsConfig
    {
        public static IServiceCollection AppAddApiDocs(this IServiceCollection services)
        {
            services.AddSwaggerDocument(opt =>
            {
                opt.Title = "ECommerce API";
                opt.SerializerSettings = JsonUtils.GetSettings();
                opt.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ECommerce API";
                };
                opt.GenerateExamples = true;
                opt.GenerateEnumMappingDescription = true;

                opt.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"));
                opt.AddSecurity("JWT token", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\" ",
                    Scheme = "Bearer"
                });
            });

            return services;
        }

        public static IApplicationBuilder AppUseApiDocs(this IApplicationBuilder app)
        {
            app.UseOpenApi();

            app.UseSwaggerUi3(opt =>
            {
                opt.Path = "/api/docs";
                //opt.DocumentPath = "/api-docs/{documentName}/swagger.json";
                opt.DocExpansion = "list";
            });
            app.UseSwagger();
            //app.UseReDoc(opt =>
            //{
            //    opt.Path = "/docs";
            //});

            return app;
        }
    }
}