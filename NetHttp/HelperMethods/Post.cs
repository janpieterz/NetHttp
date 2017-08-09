using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task <IHttpResponse> PostAsync(string url)
        {
            return CallAsync(HttpMethod.Post, url);
        }
        public Task<IHttpResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(HttpMethod.Post, url, request);
        }
        public Task<IHttpResponse> PostAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync(HttpMethod.Post, url, request);
        }
        public Task<IHttpResponse<TResponse>> PostAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(HttpMethod.Post, url, content);
        }
        public Task<IHttpResponse> PostAsync(string url, HttpContent content)
        {
            return CallAsync(HttpMethod.Post, url, content);
        }
    }
}
