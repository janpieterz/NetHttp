using System.Net;
using System.Threading.Tasks;
using NetHttp;
using Xunit;

namespace Tests
{
    public class TestParsing
    {
        [Fact]
        public async Task TestJsonParsing()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.GetAsync<IpAddressResponse>("ip");
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.False(string.IsNullOrWhiteSpace(response.Data.Origin));
            IPAddress.Parse(response.Data.Origin);
        }
        public class IpAddressResponse
        {
            public string Origin { get; set; }
        }
    }    
}
