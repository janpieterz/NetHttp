using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetHttp
{
    public partial class NetHttpClient : IDisposable, INetHttpClient
    {
        private readonly HttpClient _httpClient;
        public string BaseUrl { get; set; }
        private readonly IDeserializer _deserializer = new JsonDeserializer();
        public Dictionary<string, string> DefaultHeaders { get; } = new Dictionary<string, string>()
        {
            {"Accept", "application/json" },
            {"User-Agent", "NetHTTP/1.0" }
        };
        public NetHttpClient(string baseUrl)
        {
            BaseUrl = baseUrl ?? throw new ArgumentException(nameof(baseUrl));
            if (!BaseUrl.EndsWith("/"))
            {
                BaseUrl += "/";
            }
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }                 
        public async Task<TResponse>ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };
            var stream = await HttpSendAsync(request).ConfigureAwait(false);
            var response = await _deserializer.Deserialize<TResponse>(stream).ConfigureAwait(false);
            return response;
        }
        public async Task ExecuteAsync(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };
            var stream = await HttpSendAsync(request).ConfigureAwait(false);
            await new StreamReader(stream).ReadToEndAsync().ConfigureAwait(false);
        }
        private async Task<Stream> HttpSendAsync(HttpRequestMessage request)
        {
            foreach (KeyValuePair<string, string> keyValuePair in DefaultHeaders)
            {
                request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
            }
            
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                return stream;
            }
            string responseContent = null;
            try
            {
                responseContent = new StreamReader(stream).ReadToEnd();
            }
            catch
            {
                // ignored
            }
            if (responseContent != null)
            {
                throw new Exception(
                    $"Request to {request.RequestUri} failed. Status {(int) response.StatusCode} - {responseContent}");
            }
            throw new Exception(
                $"Request to {request.RequestUri} failed. Status {(int)response.StatusCode}");
        }
        private StringContent GetJsonContent(object @object)
        {
            var json = JsonConvert.SerializeObject(@object);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }        
    }
}
