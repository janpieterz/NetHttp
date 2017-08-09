using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task<IHttpResponse> TraceAsync(string url)
        {
            return CallAsync(HttpMethod.Trace, url);
        }
        public Task<IHttpResponse<TResponse>> TraceAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(HttpMethod.Trace, url, request);
        }
        public Task<IHttpResponse> TraceAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync(HttpMethod.Trace, url, request);
        }
        public Task<IHttpResponse<TResponse>> TraceAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(HttpMethod.Trace, url, content);
        }
        public Task<IHttpResponse> TraceAsync(string url, HttpContent content)
        {
            return CallAsync(HttpMethod.Trace, url, content);
        }        
    }
}
