using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MassTransit ve RabbitMQ ayarlar�
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<Ecommerce.Events.OrderCreated.OrderCreatedEvent>(x => x.SetEntityName("order-create-exchange"));
        cfg.Message<Ecommerce.Events.StockUpdated.StockUpdatedEvent>(x => x.SetEntityName("stock-updated-exchange"));
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
