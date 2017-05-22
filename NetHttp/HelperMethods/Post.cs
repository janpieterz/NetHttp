using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task PostAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Post, url).ConfigureAwait(false);
        }
        public Task<TResponse> PostJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PostAsync<TResponse>(url, jsonContent);
        }
        public async Task PostJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await PostAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> PostAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Post, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task PostAsync(string url, HttpContent content)
        {
            await ExecuteAsync(HttpMethod.Post, url, content).ConfigureAwait(false);
        }
    }
}
