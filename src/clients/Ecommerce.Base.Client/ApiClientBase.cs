using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Ecommerce.Base.Client.Extensions;
using Newtonsoft.Json;

namespace Ecommerce.Base.Client
{
    public class ApiClientBase : IApiClientBase
    {
        #region Fields

        private readonly string _apiServiceUrl;
        private readonly int _serviceTimeout;
        private readonly string _apiServiceBaseUrl;

        #endregion

        #region Ctor

        public ApiClientBase(string apiBaseUrl, string prefix, int serviceTimeout = 1000)
        {
            _apiServiceBaseUrl = PreventLastSlashFromUrl(apiBaseUrl);
            _apiServiceUrl = $"{_apiServiceBaseUrl}/{prefix}";
            _serviceTimeout = serviceTimeout;
        }

        #endregion

        #region Utilities

        private string PreventLastSlashFromUrl(string url)
        {
            int lastSlash = url.LastIndexOf('/');
            if (lastSlash > -1 && lastSlash == url.Length - 1)
                url = url.Substring(0, lastSlash);
            return url;
        }

        public Func<HttpClient> CreateHttpClient = () =>
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.ConnectionClose = true;
            return client;
        };

        #endregion

        #region Methods

        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest requestObject, string methodName, HttpMethod httpMethod)
        {
            using (var client = CreateHttpClient())
            {
                var url = $"{_apiServiceUrl}/{methodName}";
                if (requestObject != null && httpMethod == HttpMethod.Get)
                {
                    var query = requestObject.ToQueryString();
                    url += query;
                }

                client.Timeout = TimeSpan.FromMilliseconds(_serviceTimeout);

                var request = new HttpRequestMessage(httpMethod, url);
                if (requestObject != null && httpMethod != HttpMethod.Get)
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestObject), Encoding.UTF8, "application/json");

                using (var response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception($"{methodName} Failed: Response Status Code Not Ok! : Code: {response.StatusCode} Endpoint: {_apiServiceUrl}/{methodName}");

                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TResponse>(content);
                }
            }
        }

        #endregion
    }
}
