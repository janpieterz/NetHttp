using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task<IHttpResponse> DeleteAsync(string url)
        {
            return CallAsync(HttpMethod.Delete, url);
        }
        public Task<IHttpResponse<TResponse>> DeleteAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(HttpMethod.Delete, url, request);
        }
        public Task<IHttpResponse> DeleteAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync<TRequest>(HttpMethod.Delete, url, request);
        }
        public Task<IHttpResponse<TResponse>> DeleteAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(HttpMethod.Delete, url, content);
        }

        public Task<IHttpResponse> DeleteAsync(string url, HttpContent content)
        {
            return CallAsync(HttpMethod.Delete, url, content);
        }
    }
}
