using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task TraceAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Trace, url).ConfigureAwait(false);
        }
        public Task<TResponse> TraceJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return TraceAsync<TResponse>(url, jsonContent);
        }
        public async Task TraceJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await TraceAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> TraceAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Trace, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task TraceAsync(string url, HttpContent content)
        {
            await ExecuteAsync(HttpMethod.Trace, url, content).ConfigureAwait(false);
        }
    }
}
