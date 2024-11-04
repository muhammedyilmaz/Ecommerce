using Ecommerce.Base.Client.Models;
using Ecommerce.Order.API.Models;

namespace Ecommerce.Order.API.Repositories
{
    public interface IOrderRepository
    {
        Task<EcommerceClientResponse<OrderModel>> CreateOrder(OrderCreatedRequest model);
    }
}
