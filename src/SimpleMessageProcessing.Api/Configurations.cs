using Microsoft.Net.Http.Headers;
using SimpleMessageProcessing.Library.Converters;
using SimpleMessageProcessing.Library.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleMessageProcessing.Api {
    public static class Configurations
    {
        public static class ConfigKeys {
            public const string CorsPaths = "CorsPaths";
            public const string SystemSettings = "SystemSettings";
        }

        /// <summary>
        /// Configure Settings/Configuration for Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureSystemConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Url Shorten Settings
            var systemSettings = new SystemSettings();
            configuration.GetSection(ConfigKeys.SystemSettings).Bind(systemSettings);
            services.AddSingleton(systemSettings);
        }

        /// <summary>
        /// Allow CORS 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuraton"></param>
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuraton)
        {

            List<string> corsPath = new List<string>();
            configuraton.GetSection(ConfigKeys.CorsPaths).Bind(corsPath);

            string[] headers = new string[] {
                HeaderNames.ContentType, HeaderNames.CacheControl, HeaderNames.ETag,
                HeaderNames.UserAgent, HeaderNames.SetCookie, HeaderNames.Cookie,
                HeaderNames.AccessControlAllowCredentials,HeaderNames.Authorization};

            services.AddCors(options =>
            {
                options.AddPolicy(name: Constants.Cors.AllowedOriginsPolicy,
                    builder =>
                    {
                        builder.WithOrigins(corsPath.ToArray())
                        .AllowAnyHeader()
                        //.WithHeaders(headers)
                        .AllowCredentials()
                        .AllowAnyMethod();
                    });
            });
        }


        public static JsonSerializerOptions GetJsonSerializerOption()
        {
            return new JsonSerializerOptions
            {
                //Converters = new List<JsonConverter>() { new LongToStringJsonConverter()),
                NumberHandling = JsonNumberHandling.WriteAsString,
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new LongToStringJsonConverter()
                }
            };
        }
    }
}
