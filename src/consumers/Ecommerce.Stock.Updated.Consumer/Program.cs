using Ecommerce.Gateway.API.Client.ApiClients;
using Ecommerce.Stock.Updated.Consumer;
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
            x.AddConsumer<StockCreatedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Consumer için ReceiveEndpoint yapılandırması
                cfg.ReceiveEndpoint("stock-updated-queue", e =>
                {
                    e.ConfigureConsumer<StockCreatedEventConsumer>(context);
                });

                cfg.Message<Ecommerce.Events.StockUpdated.StockUpdatedEvent>(x => x.SetEntityName("stock-updated-exchange"));

            });
        });
    });



await builder.RunConsoleAsync();

public class StockCreatedEventConsumer : IConsumer<Ecommerce.Events.StockUpdated.StockUpdatedEvent>
{
    private readonly IGatewayApiClient _gatewayApiClient;
    public StockCreatedEventConsumer(IGatewayApiClient gatewayApiClient)
    {
        _gatewayApiClient = gatewayApiClient;
    }

    public async Task Consume(ConsumeContext<Ecommerce.Events.StockUpdated.StockUpdatedEvent> context)
    {
        var order = context.Message;

        var updateStockRequest = new Ecommerce.Stock.API.Client.Models.Requests.UpdateStockRequest
        {
            Stocks = order.Order.OrderItems.Select(x => new Ecommerce.Stock.API.Client.Models.Dto.UpdateStockDto
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        };

        await _gatewayApiClient.UpdateStock(updateStockRequest);

        return;
    }
}

