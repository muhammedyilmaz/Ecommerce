using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Base.Client
{
    public interface IApiClientBase
    {
        #region Methods

        Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest requestObject, string methodName, HttpMethod httpMethod);

        #endregion
    }
}
