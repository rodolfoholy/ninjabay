using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using SenacSp.ProjetoIntegrador.Web.Config.Bootstrap;
using SenacSp.ProjetoIntegrador.Web.Config.ActionFilter;
using SenacSp.ProjetoIntegrador.Logging;

namespace SenacSp.ProjetoIntegrador.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        private const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration,
            IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine(Env.EnvironmentName);

            services
                .AppAddMvc()
                .AddCors(options =>
                {
                    options.AddPolicy(CorsPolicy,
                        builder =>
                            builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithOrigins(Configuration.GetSection("AppConfig:BaseUrl").Value)
                                .AllowCredentials());
                })
                .AppAddCompression()
                .AppAddAuthentication(Configuration, Env)
                .AppAddDatabase(Configuration)
                .AppAddApiDocs()
                .AppAddIoCServices(Configuration)
                .AppAddMediator();
                //.AppAddSpa()

            if (Env.IsProduction())
            {
                services.AddHttpsRedirection(options =>
                {
                    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                    options.HttpsPort = 443;
                });
            }
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseStaticFiles();
            //app.UseResponseCompression();


            //app.AppUseHealthChecks();
            app.ConfigureExceptionHandler();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors(CorsPolicy);
            app.UseAuthorization();
            app.AppUseApiDocs();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.AppUseMigrations(Configuration, env);
            //app.AppUseSpa(env);


            //AppLoggerFactory.GetLogger().Info("Appliction starts");
        }
    }
}