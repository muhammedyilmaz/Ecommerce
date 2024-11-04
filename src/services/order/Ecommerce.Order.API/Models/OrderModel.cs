using Ecommerce.Order.API.Enums;

namespace Ecommerce.Order.API.Models
{
    public class OrderModel
    {
        #region Properties

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemModel> OrderItems { get; set; }

        public OrderModel()
        {
            OrderItems = new List<OrderItemModel>();
        }

        #endregion
    }

    public class OrderItemModel
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
