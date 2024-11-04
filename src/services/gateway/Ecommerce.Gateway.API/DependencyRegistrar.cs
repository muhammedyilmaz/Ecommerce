using Ecommerce.Gateway.API.Settings;
using Ecommerce.Notification.API.Client.ApiClients;
using Ecommerce.Order.API.Client.ApiClients;
using Ecommerce.Publisher.API.Client.ApiClients;
using Ecommerce.Stock.API.Client.ApiClients;
using Microsoft.Extensions.Options;

namespace Ecommerce.Gateway.API
{
    public static class DependencyRegistrar
    {
        #region ApiClient Dependencies

        public static IServiceCollection AddApiClientDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Publisher

            services.Configure<PublisherApiClientSettings>(configuration.GetSection("PublisherApiSetting"));
            services.AddScoped<IPublisherApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<PublisherApiClientSettings>>().Value;
                return new PublisherApiClient(options.ApiUrl, options.Prefix, options.ServiceTimeout);
            });

            #endregion

            #region Order

            services.Configure<OrderApiClientSettings>(configuration.GetSection("OrderApiSetting"));
            services.AddScoped<IOrderApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<OrderApiClientSettings>>().Value;
                return new OrderApiClient(options.ApiUrl, options.Prefix, options.ServiceTimeout);
            });

            #endregion

            #region Stock

            services.Configure<StockApiClientSettings>(configuration.GetSection("StockApiSetting"));
            services.AddScoped<IStockApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<StockApiClientSettings>>().Value;
                return new StockApiClient(options.ApiUrl, options.Prefix, options.ServiceTimeout);
            });

            #endregion

            #region Notification

            services.Configure<NotificationApiClientSettings>(configuration.GetSection("NotificationApiSetting"));
            services.AddScoped<INotificationApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<NotificationApiClientSettings>>().Value;
                return new NotificationApiClient(options.ApiUrl, options.Prefix, options.ServiceTimeout);
            });

            #endregion

            return services;
        }

        #endregion
    }
}
