using Ecommerce.Gateway.API.Client.ApiClients;
using Ecommerce.Order.Created.Consumer.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ecommerce.Order.Created.Consumer
{
    public static class DependencyRegistrar
    {
        #region ApiClient Dependencies

        public static IServiceCollection AddApiClientDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Gateway

            services.Configure<GatewayApiClientSettings>(configuration.GetSection("GatewayApiSetting"));

            services.AddScoped<IGatewayApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<GatewayApiClientSettings>>().Value;
                return new GatewayApiClient(options.ApiUrl, options.Prefix, options.ServiceTimeout);
            });

            #endregion

            return services;
        }

        #endregion
    }
}
