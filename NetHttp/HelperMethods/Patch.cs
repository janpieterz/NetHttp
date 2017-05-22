using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{    
    public partial class NetHttpClient
    {
        private HttpMethod _patch = new HttpMethod("PATCH");
        public async Task PatchAsync(string url)
        {
            await ExecuteAsync(_patch, url).ConfigureAwait(false);
        }
        public Task<TResponse> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PatchAsync<TResponse>(url, jsonContent);
        }
        public async Task PatchJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await PatchAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> PatchAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(_patch, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task PatchAsync(string url, HttpContent content)
        {
            await ExecuteAsync(_patch, url, content).ConfigureAwait(false);
        }
    }
}
