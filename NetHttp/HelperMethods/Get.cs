using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task<IHttpResponse<TResponse>> GetAsync<TResponse>(string url)
        {
            var response = await ReadAsync<TResponse>(HttpMethod.Get, url).ConfigureAwait(false);
            return response;
        }
    }
}
