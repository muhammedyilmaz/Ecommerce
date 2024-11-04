using Ecommerce.Publisher.API.Models;

namespace Ecommerce.Events.OrderCreated
{
    public class OrderCreatedEvent
    {
        #region Properties

        public PublisherOrderModel Order { get; set; }

        #endregion
    }
}
