namespace Ecommerce.Stock.API.Models
{
    public class UpdateStockModel
    {
        public List<UpdateStockDto> Stocks { get; set; }
    }

    public class UpdateStockDto
    {
        #region Properties

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        #endregion
    }
}
