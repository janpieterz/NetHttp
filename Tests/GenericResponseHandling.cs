using System;
using System.Net;
using System.Threading.Tasks;
using NetHttp;
using Xunit;

namespace Tests
{
    public class GenericResponseHandling
    {
        [Fact]
        public async Task ValidResponse()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            var response = await client.PostAsync("status/200").ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
        }
        [Fact]
        public async Task ValidPostWithContent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            Guid guid = Guid.NewGuid();
            var response = await client.PostJsonAsync<TestRequest, TestResponse>("post", new TestRequest()
            {
                Test = guid.ToString()
            }).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
            Assert.False(string.IsNullOrWhiteSpace(response.Content));
            Assert.True(response.Content.Contains(guid.ToString()));
            Assert.Equal(guid.ToString(), response.Data.Json.Test);
        }
        [Fact]
        public async Task ValidPutWithContent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            Guid guid = Guid.NewGuid();
            var response = await client.PutJsonAsync<TestRequest, TestResponse>("put", new TestRequest()
            {
                Test = guid.ToString()
            }).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
            Assert.False(string.IsNullOrWhiteSpace(response.Content));
            Assert.True(response.Content.Contains(guid.ToString()));
            Assert.Equal(guid.ToString(), response.Data.Json.Test);
        }
        [Fact]
        public async Task ValidPatchWithContent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            Guid guid = Guid.NewGuid();
            var response = await client.PatchJsonAsync<TestRequest, TestResponse>("patch", new TestRequest()
            {
                Test = guid.ToString()
            }).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
            Assert.False(string.IsNullOrWhiteSpace(response.Content));
            Assert.True(response.Content.Contains(guid.ToString()));
            Assert.Equal(guid.ToString(), response.Data.Json.Test);
        }
        [Fact]
        public async Task ValidDeleteWithContent()
        {
            INetHttpClient client = new NetHttpClient("https://httpbin.org");
            Guid guid = Guid.NewGuid();
            var response = await client.DeleteJsonAsync<TestRequest, TestResponse>("delete", new TestRequest()
            {
                Test = guid.ToString()
            }).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessful);
            Assert.False(string.IsNullOrWhiteSpace(response.Content));
            Assert.True(response.Content.Contains(guid.ToString()));
            Assert.Equal(guid.ToString(), response.Data.Json.Test);
        }
    }

    public class TestRequest
    {
        public string Test { get; set; }
    }
    public class TestResponse
    {
        public TestRequest Json { get; set; }
    }
}
