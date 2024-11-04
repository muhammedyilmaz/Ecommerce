namespace Ecommerce.Stock.API.Entities
{
    public class Stock
    {
        #region Properties

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
