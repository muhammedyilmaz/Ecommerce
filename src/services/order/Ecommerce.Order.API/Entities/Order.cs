using Ecommerce.Order.API.Enums;

namespace Ecommerce.Order.API.Entities
{
    public class Order
    {
        #region Properties

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        #endregion
    }
}
