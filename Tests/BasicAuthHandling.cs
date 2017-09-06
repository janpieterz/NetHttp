using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace NetHttp.Tests
{
    public class BasicAuthHandling
    {
        [Fact]
        public async Task ValidUserNamePassword()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            client.SetBasicAuthCredentials("test456", "123987");
            var response = await client.GetAsync<AuthenticationResult>("basic-auth/test456/123987").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
            Assert.Equal("test456", response.Data.User);
            Assert.True(response.Data.Authenticated);
        }

        [Fact]
        public async Task InvalidUserName()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            client.SetBasicAuthCredentials("test457", "123987");
            var response = await client.GetAsync<AuthenticationResult>("basic-auth/test456/123987").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.False(response.IsSuccessful);
        }

        [Fact]
        public async Task InvalidPassword()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            client.SetBasicAuthCredentials("test456", "123986");
            var response = await client.GetAsync<AuthenticationResult>("basic-auth/test456/123987").ConfigureAwait(false);
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.False(response.IsSuccessful);
        }
    }

    public class AuthenticationResult
    {
        public bool Authenticated { get; set; }
        public string User { get; set; }
    }
}
