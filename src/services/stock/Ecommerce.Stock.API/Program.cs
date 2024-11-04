using Ecommerce.Entities.Entities.Stock.API.Seeders;
using Ecommerce.Stock.API;
using Ecommerce.Stock.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("StockDatabase")));

builder.Services.AddScoped<IStockRepository, StockRepository>();

// Add services to the container.

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

// Dummy verileri eklemek için StockDataSeeder'ý çaðýrýn
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StockDbContext>();
    var seeder = new StockDataSeeder(context);
    await seeder.SeedAsync(); // Dummy verileri ekle
}

app.Run();
