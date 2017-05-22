using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient
    {
        public async Task HeadAsync(string url)
        {
            await ExecuteAsync(HttpMethod.Head, url).ConfigureAwait(false);
        }        
    }
}
