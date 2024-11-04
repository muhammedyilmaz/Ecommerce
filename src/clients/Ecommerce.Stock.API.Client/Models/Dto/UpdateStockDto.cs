namespace Ecommerce.Stock.API.Client.Models.Dto
{
    public class UpdateStockDto
    {
        #region Properties

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        #endregion
    }
}
