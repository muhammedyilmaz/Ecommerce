using Ecommerce.Notification.Log.Consumer.Models;

namespace Ecommerce.Events.StockUpdated
{
    public class StockUpdatedEvent
    {
        #region Properties

        public PublisherOrderModel Order { get; set; }

        #endregion
    }
}
