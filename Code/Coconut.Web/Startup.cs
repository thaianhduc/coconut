using System.Threading.Tasks;
using Coconut.CoreLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Coconut.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appComplexSettings.json");

            _configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the ability to read options in configuration
            services.AddOptions();
            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.Configure<GlobalSettings>(_configuration);
            services.AddSingleton(_configuration);
            services.AddRouting();
            services.AddMvc();

            services.AddTransient<UglyFactTeller>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
