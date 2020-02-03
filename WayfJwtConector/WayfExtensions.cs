
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using WayfJwtConector;

namespace WayfJwtConector
{
     public static class WayfJwtConector
    {
        public static WayfBuilder AddWayf(this IServiceCollection services, IConfigurationSection config)
        {
            var conf = config.Get<WayfOptions>();
            services.AddOptions();
            services.Configure<WayfOptions>(config);
            services.AddSingleton<WayfClient, WayfClient>();
            services.ConfigureHttpClient(conf);
            return new WayfBuilder(services);
        }

        private static void ConfigureHttpClient(this IServiceCollection services, WayfOptions options)
        {
            services.AddHttpClient<WayfHttpClientFactory>()
                   .ConfigureWayfMessageHandler();
        }


        internal static IHttpClientBuilder ConfigureWayfMessageHandler(this IHttpClientBuilder builder)
        {
            return builder.ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler()
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    AllowAutoRedirect = false
                };
                return handler;
            });
        }

    }
}
