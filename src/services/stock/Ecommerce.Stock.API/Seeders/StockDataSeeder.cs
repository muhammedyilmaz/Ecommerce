using Ecommerce.Stock.API;

namespace Ecommerce.Entities.Entities.Stock.API.Seeders
{
    public class StockDataSeeder
    {
        private readonly StockDbContext _context;

        public StockDataSeeder(StockDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (_context.Stocks.Any())
            {
                return;
            }

            var dummyStocks = new List<Ecommerce.Stock.API.Entities.Stock>
            {
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 1, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 2, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 3, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 4, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 5, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 6, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 7, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 8, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 9, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
                new Ecommerce.Stock.API.Entities.Stock { ProductId = 10, Quantity = 1000, UpdatedAt = DateTime.UtcNow },
            };

            for (int i = 11; i <= 100; i++)
            {
                dummyStocks.Add(new Ecommerce.Stock.API.Entities.Stock
                {
                    ProductId = i,
                    Quantity = new Random().Next(1, 101),
                    UpdatedAt = DateTime.UtcNow
                });
            }

            await _context.Stocks.AddRangeAsync(dummyStocks);
            await _context.SaveChangesAsync();
        }
    }
}



