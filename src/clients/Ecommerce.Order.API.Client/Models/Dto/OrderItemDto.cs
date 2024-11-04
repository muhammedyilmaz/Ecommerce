namespace Ecommerce.Order.API.Client.Models.Dto
{
    public class OrderItemDto
    {
        #region Properties

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        #endregion
    }
}
