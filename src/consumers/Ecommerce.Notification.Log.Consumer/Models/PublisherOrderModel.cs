namespace Ecommerce.Notification.Log.Consumer.Models
{
    public class PublisherOrderModel
    {
        #region Properties

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public byte Status { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PublisherOrderItemModel> OrderItems { get; set; }

        #endregion
    }
}
