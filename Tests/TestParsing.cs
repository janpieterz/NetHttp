using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NetHttp.Tests
{
    public class TestParsing
    {
        [Fact]
        public async Task TestJsonParsing()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.GetAsync<IpAddressResponse>("ip").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.False(string.IsNullOrWhiteSpace(response.Data.Origin));
            IPAddress.Parse(response.Data.Origin);
        }
        [Fact]
        public async Task FailParsing()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.GetAsync<FailIpResponse>("ip").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.False(response.IsSuccessful);
            Assert.NotNull(response.Exception);
            Assert.Equal(typeof(DeserialisationException), response.Exception.GetType());
        }
        public class IpAddressResponse
        {
            public string Origin { get; set; }
        }
        public class FailIpResponse
        {
            public DateTime Origin { get; set; }
        }
    }    
}
