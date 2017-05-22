using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public interface INetHttpClient : IDisposable
    {
        Task<TResponse> ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null);
        Task ExecuteAsync(HttpMethod method, string url, HttpContent content = null);
        Dictionary<string, string> DefaultHeaders { get; }
        Task DeleteAsync(string url);
        Task<TResponse> DeleteJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task DeleteJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> DeleteAsync<TResponse>(string url, HttpContent content);
        Task DeleteAsync(string url, HttpContent content);
        Task<TResponse> GetAsync<TResponse>(string url);
        Task HeadAsync(string url);
        Task OptionsAsync(string url);
        Task<TResponse> OptionsJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task OptionsJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> OptionsAsync<TResponse>(string url, HttpContent content);
        Task OptionsAsync(string url, HttpContent content);
        Task PatchAsync(string url);
        Task<TResponse> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task PatchJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> PatchAsync<TResponse>(string url, HttpContent content);
        Task PatchAsync(string url, HttpContent content);
        Task PostAsync(string url);
        Task<TResponse> PostJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task PostJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> PostAsync<TResponse>(string url, HttpContent content);
        Task PostAsync(string url, HttpContent content);
        Task PutAsync(string url);
        Task<TResponse> PutJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task PutJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> PutAsync<TResponse>(string url, HttpContent content);
        Task PutAsync(string url, HttpContent content);
        Task TraceAsync(string url);
        Task<TResponse> TraceJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task TraceJsonAsync<TRequest>(string url, TRequest request);
        Task<TResponse> TraceAsync<TResponse>(string url, HttpContent content);
        Task TraceAsync(string url, HttpContent content);
    }
}