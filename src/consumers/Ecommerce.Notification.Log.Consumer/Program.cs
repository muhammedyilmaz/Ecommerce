using Ecommerce.Gateway.API.Client.ApiClients;
using Ecommerce.Notification.Log.Consumer;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddApiClientDependencies(hostContext.Configuration);
        services.AddMassTransit(x =>
        {
            x.AddConsumer<NotificationCreatedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Consumer için ReceiveEndpoint yapılandırması
                cfg.ReceiveEndpoint("notification-log-queue", e =>
                {
                    e.ConfigureConsumer<NotificationCreatedEventConsumer>(context);
                });

                cfg.Message<Ecommerce.Events.StockUpdated.StockUpdatedEvent>(x => x.SetEntityName("stock-updated-exchange"));

            });
        });
    });



await builder.RunConsoleAsync();

public class NotificationCreatedEventConsumer : IConsumer<Ecommerce.Events.StockUpdated.StockUpdatedEvent>
{
    private readonly IGatewayApiClient _gatewayApiClient;
    public NotificationCreatedEventConsumer(IGatewayApiClient gatewayApiClient)
    {
        _gatewayApiClient = gatewayApiClient;
    }

    public async Task Consume(ConsumeContext<Ecommerce.Events.StockUpdated.StockUpdatedEvent> context)
    {
        var message = context.Message;

        var request = new Ecommerce.Notification.API.Client.Models.Requests.NotificationRequest()
        {
            IsSuccess = true,
            Message = $"{message.Order.TotalAmount} tutarında siparişiniz başarıyla oluşturuldu. Sipariş No: {message.Order.Id}",
            SentAt = DateTime.Now,
            Type = 1,
            UserId = 1
        };

        await _gatewayApiClient.CreateNotification(request);

        return;
    }
}

