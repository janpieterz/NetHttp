using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task<IHttpResponse> PutAsync(string url)
        {
            return ExecuteAsync(HttpMethod.Put, url);
        }
        public Task<IHttpResponse<TResponse>> PutAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(HttpMethod.Put, url, request);
        }
        public Task<IHttpResponse> PutAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync(HttpMethod.Put, url, request);
        }
        public Task<IHttpResponse<TResponse>> PutAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(HttpMethod.Put, url, content);
        }
        public Task<IHttpResponse> PutAsync(string url, HttpContent content)
        {
            return CallAsync(HttpMethod.Put, url, content);
        }
    }
}
