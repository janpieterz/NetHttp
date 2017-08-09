using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{    
    public partial class NetHttpClient
    {
        private readonly HttpMethod _patch = new HttpMethod("PATCH");
        public Task<IHttpResponse> PatchAsync(string url)
        {
            return CallAsync(_patch, url);
        }
        public Task<IHttpResponse<TResponse>> PatchAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(_patch, url, request);
        }
        public Task<IHttpResponse> PatchAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync(_patch, url, request);
        }
        public Task<IHttpResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(_patch, url, content);
        }
        public Task<IHttpResponse> PatchAsync(string url, HttpContent content)
        {
            return CallAsync(_patch, url, content);
        }
    }
}
