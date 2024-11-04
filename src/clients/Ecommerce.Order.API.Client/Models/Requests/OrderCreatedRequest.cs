using System.Collections.Generic;
using System;

namespace Ecommerce.Order.API.Client.Models.Requests
{
    public class OrderCreatedRequest
    {
        public CreteOrderDto Order { get; set; }
    }

    public class CreteOrderDto
    {
        #region Properties

        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<CreateOrderItemDto> OrderItems { get; set; }

        public CreteOrderDto()
        {
            OrderItems = new List<CreateOrderItemDto>();
        }

        #endregion
    }

    public class CreateOrderItemDto
    {
        #region Properties

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        #endregion
    }
}
