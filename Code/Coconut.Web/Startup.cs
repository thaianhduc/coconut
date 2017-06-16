using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Coconut.Web
{
    public class AppSettingsController
    {
        private readonly AppSettings _appSettings;
        private readonly GlobalSettings _globalSettings;
        public AppSettingsController(IOptions<AppSettings> appSettingsOptions, IOptions<GlobalSettings> globalSettingsOptions)
        {
            _appSettings = appSettingsOptions.Value;
            _globalSettings = globalSettingsOptions.Value;
        }

        public Task GetAppSettings(HttpContext context)
        {
            return context.Response.WriteAsync($"Thie is AppSettingsController: {_appSettings.Message}; " +
                                               $"EF Connection String: {_globalSettings.ConnectionStrings.Ef}; " +
                                               $"Author: {_globalSettings.Author.Name}");
        }
    }
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

            // Register a controller with a lifestyle of httprequest scoped
            services.AddScoped<AppSettingsController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseMvc();
            app.Run(HandleRequest);
        }

        public Task HandleRequest(HttpContext context)
        {
           var controller = context.RequestServices.GetRequiredService<AppSettingsController>();
            return controller.GetAppSettings(context);
        }
    }
}
