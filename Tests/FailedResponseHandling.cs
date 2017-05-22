using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
            var response = await client.PostAsync("status/500");
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
