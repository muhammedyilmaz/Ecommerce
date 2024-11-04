using Ecommerce.Base.Client.Models;
using Ecommerce.EntityFrameworkCore.Repositories;
using Ecommerce.Stock.API.Models;

namespace Ecommerce.Stock.API.Repositories
{
    public class StockRepository : EfCoreRepository<Entities.Stock, StockDbContext>, IStockRepository
    {
        #region Ctor

        public StockRepository(StockDbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockModel model)
        {

            try
            {
                var updatedStocks = new List<UpdateStockDto>();

                foreach (var stockDto in model.Stocks)
                {
                    var stock = await _context.Stocks.FindAsync(stockDto.ProductId);

                    if (stock == null)
                    {
                        throw new KeyNotFoundException($"Stock with ProductId {stockDto.ProductId} not found.");
                    }

                    // Stok miktar kontrolü
                    if (stock.Quantity < stockDto.Quantity)
                    {
                        throw new InvalidOperationException($"Insufficient stock for ProductId {stockDto.ProductId}. Current quantity: {stock.Quantity}, requested: {stockDto.Quantity}.");
                    }

                    // Stok miktarını düşür
                    stock.Quantity -= stockDto.Quantity;
                    stock.UpdatedAt = DateTime.UtcNow;

                    // db SaveChanges
                    await _context.SaveChangesAsync();

                    updatedStocks.Add(new UpdateStockDto
                    {
                        ProductId = stock.ProductId,
                        Quantity = stock.Quantity
                    });
                }

                return new EcommerceClientResponse<List<UpdateStockDto>>(updatedStocks);
            }
            catch (Exception ex)
            {
                return new EcommerceClientResponse<List<UpdateStockDto>>(ex);
            }
        }

        #endregion
    }
}