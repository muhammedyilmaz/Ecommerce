using Ecommerce.Publisher.API.Models;

namespace Ecommerce.Events.StockUpdated
{
    public class StockUpdatedEvent
    {
        #region Properties

        public PublisherOrderModel Order { get; set; }

        #endregion
    }
}
