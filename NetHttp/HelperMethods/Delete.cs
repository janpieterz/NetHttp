using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task<INetResponse> DeleteAsync(string url)
        {
            return await ExecuteAsync(HttpMethod.Delete, url).ConfigureAwait(false);
        }
        public Task<INetResponse<TResponse>> DeleteJsonAsync<TRequest, TResponse>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return DeleteAsync<TResponse>(url, jsonContent);
        }
        public async Task<INetResponse> DeleteJsonAsync<TRequest>(string url, TRequest request)
        {
            HttpContent jsonContent = GetJsonContent(request);
            return await DeleteAsync(url, jsonContent).ConfigureAwait(false);
        }
        public async Task<INetResponse<TResponse>> DeleteAsync<TResponse>(string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Delete, url, content).ConfigureAwait(false);
            return response;
        }

        public async Task<INetResponse> DeleteAsync(string url, HttpContent content)
        {
            return await ExecuteAsync(HttpMethod.Delete, url, content).ConfigureAwait(false);
        }
    }
}
