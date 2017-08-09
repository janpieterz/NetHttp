using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NetHttp.Deserializers;
using NetHttp.Serializers;

namespace NetHttp
{
    public interface INetHttpClient : IDisposable
    {
        IDeserialize Deserializer {get;set;}
        ISerialize Serializer {get;set;}
        Task<IHttpResponse<TResponse>> ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null);
        Task<IHttpResponse> ExecuteAsync(HttpMethod method, string url, HttpContent content = null);
        HttpRequestHeaders DefaultHeaders { get; }
        void SetBasicAuthCredentials(string username, string password);        
        Task<IHttpResponse<TResponse>> CallAsync<TResponse>(HttpMethod method, string url, HttpContent content);
        Task<IHttpResponse> CallAsync<TRequest>(HttpMethod method,string url, TRequest request);
        Task<IHttpResponse<TResponse>> CallAsync<TRequest, TResponse>(HttpMethod method, string url, TRequest request);
        Task<IHttpResponse> CallAsync(HttpMethod method, string url);
        Task<IHttpResponse> CallAsync(HttpMethod method, string url, HttpContent content);

        #region HTTP Method Helpers
        Task<IHttpResponse> DeleteAsync(string url);
        Task<IHttpResponse<TResponse>> DeleteAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> DeleteAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> DeleteAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> DeleteAsync(string url, HttpContent content);
        Task<IHttpResponse<TResponse>> GetAsync<TResponse>(string url);
        Task<IHttpResponse> HeadAsync(string url);
        Task<IHttpResponse> OptionsAsync(string url);
        Task<IHttpResponse<TResponse>> OptionsAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> OptionsAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> OptionsAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> OptionsAsync(string url, HttpContent content);
        Task<IHttpResponse> PatchAsync(string url);
        Task<IHttpResponse<TResponse>> PatchAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PatchAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PatchAsync(string url, HttpContent content);
        Task<IHttpResponse> PostAsync(string url);
        Task<IHttpResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PostAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PostAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PostAsync(string url, HttpContent content);
        Task<IHttpResponse> PutAsync(string url);
        Task<IHttpResponse<TResponse>> PutAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PutAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PutAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PutAsync(string url, HttpContent content);
        Task<IHttpResponse> TraceAsync(string url);
        Task<IHttpResponse<TResponse>> TraceAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> TraceAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> TraceAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> TraceAsync(string url, HttpContent content); 
        #endregion
    }
}