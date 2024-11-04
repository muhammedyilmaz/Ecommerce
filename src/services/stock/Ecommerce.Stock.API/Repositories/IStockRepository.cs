using Ecommerce.Base.Client.Models;
using Ecommerce.Stock.API.Models;

namespace Ecommerce.Stock.API.Repositories
{
    public interface IStockRepository
    {
        #region Methods

        Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockModel model);

        #endregion
    }
}
