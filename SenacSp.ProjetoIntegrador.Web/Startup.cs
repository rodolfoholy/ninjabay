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

            //if (Env.IsProduction())
            //{
            //    //services.AddHttpsRedirection(options =>
            //    //{
            //    //    options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //    //    options.HttpsPort = 443;
            //    //});
            //}
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            IServiceProvider serviceProvider)
        {
            if (env.IsProduction())
            {
                //app.UseHttpsRedirection();
                //app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }



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


            if (env.IsProduction())
            {
                AppLoggerFactory.GetLogger().Info("Build Realizado com sucesso");
            }
        }
    }
}