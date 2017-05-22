using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task OptionsAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Options, url).ConfigureAwait(false);
        }
        public Task<TResponse> OptionsJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return OptionsAsync<TResponse>(url, jsonContent);
        }
        public async Task OptionsJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            await OptionsAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<TResponse> OptionsAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Options, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task OptionsAsync(string url, HttpContent content)
        {
            await ExecuteAsync(HttpMethod.Options, url, content).ConfigureAwait(false);
        }
    }
}
