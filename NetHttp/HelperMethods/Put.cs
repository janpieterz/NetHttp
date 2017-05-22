using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task PutAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Put, url).ConfigureAwait(false);
        }
        public Task<TResponse> PutJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PutAsync<TResponse>(url, jsonContent);
        }
        public async Task PutJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await PutAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> PutAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Put, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task PutAsync(string url, HttpContent content)
        {
            await ExecuteAsync(HttpMethod.Put, url, content).ConfigureAwait(false);
        }
    }
}
