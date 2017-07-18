using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Coconut.Web
{
    public class AppSettingsController
    {
        private readonly IConfigurationRoot _configuration;
        private readonly AppSettings _appSettings;
        private readonly GlobalSettings _globalSettings;
        public AppSettingsController(
            IOptions<AppSettings> appSettingsOptions, 
            IOptions<GlobalSettings> globalSettingsOptions,
            IConfigurationRoot configuration)
        {
            _configuration = configuration;
            _appSettings = appSettingsOptions.Value;
            _globalSettings = globalSettingsOptions.Value;
        }

        public Task GetAppSettings(HttpContext context)
        {
            return context.Response.WriteAsync($"Thie is AppSettingsController: {_appSettings.Message}; " +
                                               $"EF Connection String: {_globalSettings.ConnectionStrings.Ef}; " +
                                               $"Author: {_globalSettings.Author.Name}");
        }

        public Task GetDirectAppSettings(HttpContext context)
        {
            return context.Response.WriteAsync($"Direct app setting: {_configuration["AppSettings:Message"]}");
        }
    }

}