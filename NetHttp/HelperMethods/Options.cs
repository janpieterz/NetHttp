using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task<IHttpResponse> OptionsAsync(string url)
        {
            return CallAsync(HttpMethod.Options, url);
        }
        public Task<IHttpResponse<TResponse>> OptionsAsync<TRequest, TResponse>(string url, TRequest request)
        {
            return CallAsync<TRequest, TResponse>(HttpMethod.Options, url, request);
        }
        public Task<IHttpResponse> OptionsAsync<TRequest>(string url, TRequest request)
        {
            return CallAsync<TRequest>(HttpMethod.Options, url, request);
        }
        public Task<IHttpResponse<TResponse>> OptionsAsync<TResponse>(string url, HttpContent content)
        {
            return CallAsync<TResponse>(HttpMethod.Options, url, content);
        }
        public Task<IHttpResponse> OptionsAsync(string url, HttpContent content)
        {
            return CallAsync(HttpMethod.Options, url, content);
        }
    }
}
