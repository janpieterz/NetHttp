using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{    
    public partial class NetHttpClient
    {
        private HttpMethod _patch = new HttpMethod("PATCH");
        public async Task<INetResponse> PatchAsync(string url)
        {
            return await ExecuteAsync(_patch, url).ConfigureAwait(false);
        }
        public Task<INetResponse<TResponse>> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PatchAsync<TResponse>(url, jsonContent);
        }
        public async Task<INetResponse> PatchJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return await PatchAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<INetResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(_patch, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task<INetResponse> PatchAsync(string url, HttpContent content)
        {
            return await ExecuteAsync(_patch, url, content).ConfigureAwait(false);
        }
    }
}
