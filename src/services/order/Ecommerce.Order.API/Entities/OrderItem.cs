namespace Ecommerce.Order.API.Entities
{
    public class OrderItem
    {
        #region Properties

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        #endregion
    }
}
