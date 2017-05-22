using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task DeleteAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Delete, url).ConfigureAwait(false);
        }
        public Task<TResponse> DeleteJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return DeleteAsync<TResponse>(url, jsonContent);
        }
        public async Task DeleteJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await DeleteAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> DeleteAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Delete, url, content).ConfigureAwait(false);
            return response;
        }

        public async Task DeleteAsync(string url, HttpContent content)
        {
            await ExecuteAsync(HttpMethod.Delete, url, content).ConfigureAwait(false);
        }
    }
}
