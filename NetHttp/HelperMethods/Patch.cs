using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{    
    public partial class NetHttpClient
    {
        private readonly HttpMethod _patch = new HttpMethod("PATCH");
        public async Task<IHttpResponse> PatchAsync(string url)
        {
            return await ExecuteAsync(_patch, url).ConfigureAwait(false);
        }
        public Task<IHttpResponse<TResponse>> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PatchAsync<TResponse>(url, jsonContent);
        }
        public async Task<IHttpResponse> PatchJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return await PatchAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<IHttpResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(_patch, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task<IHttpResponse> PatchAsync(string url, HttpContent content)
        {
            return await ExecuteAsync(_patch, url, content).ConfigureAwait(false);
        }
    }
}
