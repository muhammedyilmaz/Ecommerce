﻿namespace Ecommerce.Notification.Log.Consumer.Models
{
    public class PublisherOrderItemModel
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
