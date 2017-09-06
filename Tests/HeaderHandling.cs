using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NetHttp.Tests
{
    public class HeaderHandling
    {
        [Fact]
        public async Task HandlesHeaderReceiving()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.GetAsync<string>("headers").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.Headers.Any());
            Assert.True(response.Headers.Date.HasValue);
            Assert.False(response.IsSuccessful);
        }

        [Fact]
        public async Task DefaultHeaderGetSent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            Random random = new Random();
            int number = random.Next(1000, 5000);
            client.DefaultHeaders.Add("Test", number.ToString());
            var response = await client.GetAsync<string>("headers").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(response.IsSuccessful);
            Assert.Contains($"\"Test\": \"{number}\",", response.Content);
        }
    }
}
