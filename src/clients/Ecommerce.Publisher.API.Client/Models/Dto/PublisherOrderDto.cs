using System;
using System.Collections.Generic;

namespace Ecommerce.Publisher.API.Client.Models.Dto
{
    public class PublisherOrderDto
    {
        #region Properties

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PublisherOrderItemDto> OrderItems { get; set; }

        #endregion
    }
}
