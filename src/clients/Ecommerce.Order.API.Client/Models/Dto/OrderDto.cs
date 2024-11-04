using System;
using System.Collections.Generic;

namespace Ecommerce.Order.API.Client.Models.Dto
{
    public class OrderDto
    {
        #region Properties

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }

        #endregion
    }
}
