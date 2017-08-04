using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public interface INetHttpClient : IDisposable
    {
        Task<IHttpResponse<TResponse>> ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null);
        Task<IHttpResponse> ExecuteAsync(HttpMethod method, string url, HttpContent content = null);
        Dictionary<string, string> DefaultHeaders { get; }
        void SetBasicAuthCredentials(string username, string password);

        #region HTTP Method Helpers
        Task<IHttpResponse> DeleteAsync(string url);
        Task<IHttpResponse<TResponse>> DeleteJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> DeleteJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> DeleteAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> DeleteAsync(string url, HttpContent content);
        Task<IHttpResponse<TResponse>> GetAsync<TResponse>(string url);
        Task<IHttpResponse> HeadAsync(string url);
        Task<IHttpResponse> OptionsAsync(string url);
        Task<IHttpResponse<TResponse>> OptionsJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> OptionsJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> OptionsAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> OptionsAsync(string url, HttpContent content);
        Task<IHttpResponse> PatchAsync(string url);
        Task<IHttpResponse<TResponse>> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PatchJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PatchAsync(string url, HttpContent content);
        Task<IHttpResponse> PostAsync(string url);
        Task<IHttpResponse<TResponse>> PostJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PostJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PostAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PostAsync(string url, HttpContent content);
        Task<IHttpResponse> PutAsync(string url);
        Task<IHttpResponse<TResponse>> PutJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> PutJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> PutAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> PutAsync(string url, HttpContent content);
        Task<IHttpResponse> TraceAsync(string url);
        Task<IHttpResponse<TResponse>> TraceJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<IHttpResponse> TraceJsonAsync<TRequest>(string url, TRequest request);
        Task<IHttpResponse<TResponse>> TraceAsync<TResponse>(string url, HttpContent content);
        Task<IHttpResponse> TraceAsync(string url, HttpContent content); 
        #endregion
    }
}