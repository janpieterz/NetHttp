using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task<IHttpResponse> HeadAsync(string url)
        {
            return await ExecuteAsync(HttpMethod.Head, url).ConfigureAwait(false);
        }        
    }
}
