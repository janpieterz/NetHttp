using System.Net;
using System.Threading.Tasks;
using NetHttp;
using Xunit;

namespace Tests
{
    public class FailedResponseHandling
    {
        [Fact]
        public async Task InvalidResponseReturnsObject()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.PostAsync("status/500").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.False(response.IsSuccessful);
        }
        [Fact]
        public async Task HandleUnauthorized()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.PostAsync("status/401").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.False(response.IsSuccessful);
        }
        [Fact]
        public async Task HandleFailContent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.PostAsync("status/418").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(418, (int)response.StatusCode);
            Assert.False(response.IsSuccessful);
        }

        [Fact]
        public async Task HandleUnknownDomain()
        {
            INetHttpClient client = new NetHttpClient("https://z93nu5z9.com/");
            var response = await client.PostAsync("random").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(0, (int)response.StatusCode);
            Assert.False(response.IsSuccessful);
            Assert.Equal("An error occurred while sending the request.", response.Exception.Message);
            Assert.NotNull(response.Exception.InnerException);
            Assert.Equal("The server name or address could not be resolved", response.Exception.InnerException.Message);
        }
    }
}
