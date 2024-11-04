using Ecommerce.Order.API.Enums;

namespace Ecommerce.Order.API.Models
{
    public class OrderCreatedRequest
    {
        public OrderDto Order { get; set; }
    }

    public class OrderDto
    {
        #region Properties

        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        #endregion
    }

    public class OrderItemDto
    {
        #region Properties

        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        #endregion
    }
}
