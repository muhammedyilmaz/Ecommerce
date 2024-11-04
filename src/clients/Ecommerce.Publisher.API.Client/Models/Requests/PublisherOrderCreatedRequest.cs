using Ecommerce.Publisher.API.Client.Models.Dto;

namespace Ecommerce.Publisher.API.Client.Models.Requests
{
    public class PublisherOrderCreatedRequest
    {
        #region Properties

        public PublisherOrderDto Order { get; set; }

        #endregion
    }
}
