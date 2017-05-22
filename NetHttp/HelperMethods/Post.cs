using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task <INetResponse> PostAsync(string url)
        {
            return await ExecuteAsync(HttpMethod.Post, url).ConfigureAwait(false);
        }
        public Task<INetResponse<TResponse>> PostJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return PostAsync<TResponse>(url, jsonContent);
        }
        public async Task<INetResponse> PostJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return await PostAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<INetResponse<TResponse>> PostAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Post, url, content).ConfigureAwait(false);
            return response;
        }
        public async Task<INetResponse> PostAsync(string url, HttpContent content)
        {
            return await ExecuteAsync(HttpMethod.Post, url, content).ConfigureAwait(false);
        }
    }
}
