using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public Task<IHttpResponse> HeadAsync(string url)
        {
            return CallAsync(HttpMethod.Head, url);
        }        
    }
}
