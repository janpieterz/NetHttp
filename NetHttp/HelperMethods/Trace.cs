using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task<INetResponse> TraceAsync(string url)
        {
            return await ExecuteAsync(HttpMethod.Trace, url).ConfigureAwait(false);
        }
        public Task<INetResponse<TResponse>> TraceJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return TraceAsync<TResponse>(url, jsonContent);
        }
        public async Task<INetResponse> TraceJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return await TraceAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<INetResponse<TResponse>> TraceAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Trace, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task<INetResponse> TraceAsync(string url, HttpContent content)
        {
            return await ExecuteAsync(HttpMethod.Trace, url, content).ConfigureAwait(false);
        }
    }
}
