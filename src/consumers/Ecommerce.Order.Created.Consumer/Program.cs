using Ecommerce.Gateway.API.Client.ApiClients;
using Ecommerce.Order.Created.Consumer;
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
            x.AddConsumer<OrderCreatedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Consumer için ReceiveEndpoint yapılandırması
                cfg.ReceiveEndpoint("order-created-queue", e =>
                {
                    e.ConfigureConsumer<OrderCreatedEventConsumer>(context);
                });

                cfg.Message<Ecommerce.Events.OrderCreated.OrderCreatedEvent>(x => x.SetEntityName("order-create-exchange"));

            });
        });
    });



await builder.RunConsoleAsync();

public class OrderCreatedEventConsumer : IConsumer<Ecommerce.Events.OrderCreated.OrderCreatedEvent>
{
    private readonly IGatewayApiClient _gatewayApiClient;
    public OrderCreatedEventConsumer(IGatewayApiClient gatewayApiClient)
    {
        _gatewayApiClient = gatewayApiClient;
    }

    public async Task Consume(ConsumeContext<Ecommerce.Events.OrderCreated.OrderCreatedEvent> context)
    {
        var order = context.Message;

        //create order db
        var responseCreateOrder = await _gatewayApiClient.CreateOrder(new Ecommerce.Order.API.Client.Models.Requests.OrderCreatedRequest()
        {
            Order = new Ecommerce.Order.API.Client.Models.Requests.CreteOrderDto()
            {
                CustomerId = order.Order.CustomerId,
                OrderDate = order.Order.OrderDate,
                Status = order.Order.Status,
                TotalAmount = order.Order.TotalAmount,
                OrderItems = order.Order.OrderItems.Select(x => new Ecommerce.Order.API.Client.Models.Requests.CreateOrderItemDto()
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList()
            }
        });

        if (responseCreateOrder.IsSuccess)
        {
            var data = responseCreateOrder.Data;

            await _gatewayApiClient.SendStockUpdateToQueue(new Ecommerce.Publisher.API.Client.Models.Requests.PublisherOrderCreatedRequest()
            {
                Order = new Ecommerce.Publisher.API.Client.Models.Dto.PublisherOrderDto()
                {
                    Id = data.Id,
                    CustomerId = data.CustomerId,
                    OrderDate = data.OrderDate,
                    Status = data.Status,
                    TotalAmount = data.TotalAmount,
                    OrderItems = data.OrderItems.Select(x => new Ecommerce.Publisher.API.Client.Models.Dto.PublisherOrderItemDto()
                    {
                        Id = x.Id,
                        OrderId = x.OrderId,
                        ProductId = x.ProductId,
                        ProductName = x.ProductName,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice
                    }).ToList()
                }
            });
        }
        else
        {
            //log atılabilir retry mekanizması uygulanabilir. yada order silinmesi gerekir.
            return;
        }
    }
}

