using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NetHttp.Serializers;
using NetHttp.Deserializers;

namespace NetHttp
{
    public partial class NetHttpClient : INetHttpClient
    {
        private readonly HttpClient _httpClient;
        public string BaseUrl { get; set; }
        public IDeserialize Deserializer {get;set;} = new JsonDeserializer();
        public ISerialize Serializer {get;set;} = new JsonSerializer();
        public HttpRequestHeaders DefaultHeaders => _httpClient.DefaultRequestHeaders;

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
            DefaultHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultHeaders.UserAgent.Add(new ProductInfoHeaderValue("NetHTTP", "1.0"));
        }

        public void SetBasicAuthCredentials(string username, string password)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));
        }
        
        public async Task<IHttpResponse> CallAsync(HttpMethod method, string url, HttpContent content){
            return await ExecuteAsync(method, url, content).ConfigureAwait(false);
        }
        public async Task<IHttpResponse> CallAsync(HttpMethod method, string url)
        {
            return await ExecuteAsync(method, url).ConfigureAwait(false);
        }
        public async Task<IHttpResponse<TResponse>> CallAsync<TRequest, TResponse>(HttpMethod method, string url, TRequest request)
        {
            HttpContent content = await GetSerializedContent(request).ConfigureAwait(false);
            return await CallAsync<TResponse>(method, url, content).ConfigureAwait(false);
        }
        public async Task<IHttpResponse> CallAsync<TRequest>(HttpMethod method,string url, TRequest request)
        {
            HttpContent content = await GetSerializedContent(request).ConfigureAwait(false);
            return await CallAsync(method, url, content).ConfigureAwait(false);
        }
        public async Task<IHttpResponse<TResponse>> CallAsync<TResponse>(HttpMethod method, string url, HttpContent content)
        {
            var response = await ReadAsync<TResponse>(method, url, content).ConfigureAwait(false);
            return response;
        }

        public async Task<IHttpResponse<TResponse>> ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };
            var sendResponse = await HttpSendAsync(request).ConfigureAwait(false);
            var response = new HttpResponse<TResponse>()
            {
                Content = sendResponse.Content,
                StatusCode = sendResponse.StatusCode,
                Headers = sendResponse.Headers
            };
            //If HttpSendAsync already adds exception request has already failed.
            if(response.Exception == null)
            {
                try
                {
                    var typedData = await Deserializer.Deserialize<TResponse>(response.Content).ConfigureAwait(false);
                    response.Data = typedData;
                }
                catch (Exception exception)
                {
                    response.Exception = new DeserialisationException(exception);
                }
            }           
            
            return response;
        }
        public async Task<IHttpResponse> ExecuteAsync(HttpMethod method, string url, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content
            };
            var sendResponse = await HttpSendAsync(request).ConfigureAwait(false);            
            return sendResponse;
        }
        private async Task<IHttpResponse> HttpSendAsync(HttpRequestMessage request)
        {
            var typedResponse = new HttpResponse();
            try
            {
                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                typedResponse = new HttpResponse {StatusCode = response.StatusCode, Headers = response.Headers};
                try
                {
                    typedResponse.Content = new StreamReader(stream).ReadToEnd();
                }
                catch (Exception exception)
                {
                    typedResponse.Exception = new ContentReadException(exception);
                }
            }
            catch (HttpRequestException requestException)
            {
                typedResponse.Exception = requestException;
            }
            
            return typedResponse;            
        }
        private async Task<StringContent> GetSerializedContent(object @object){
            var content = await Serializer.Serialize(@object).ConfigureAwait(false);
            return new StringContent(content, Encoding.UTF8, Serializer.ContentType);
        }
        public void Dispose()
        {
            _httpClient?.Dispose();
        }        
    }
}
