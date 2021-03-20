using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NinjaBay.Logging;
using NinjaBay.Web.Config.ActionFilter;
using NinjaBay.Web.Config.Bootstrap;

namespace NinjaBay.Web
{
    public class Startup
    {
        private const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration,
            IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AppAddMvc()
                .AddCors(options =>
                {
                    options.AddPolicy(CorsPolicy,
                        builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                })
                .AppAddCompression()
                .AppAddAuthentication(Configuration, Env)
                .AppAddIoCServices(Configuration)
                .AppAddDatabase(Configuration)
                .AppAddApiDocs()
                .AppAddMediator();
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseResponseCompression();


            app.ConfigureExceptionHandler();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(CorsPolicy);
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.AppUseApiDocs();
            app.AppUseMigrations(Configuration, env);
            
            AppLoggerFactory.GetLogger().Info("Build Realizado com sucesso");
        }
    }
}