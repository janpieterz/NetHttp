using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetHttp
{
    public interface INetHttpClient : IDisposable
    {
        Task<INetResponse<TResponse>> ReadAsync<TResponse>(HttpMethod method, string url, HttpContent content = null);
        Task<INetResponse> ExecuteAsync(HttpMethod method, string url, HttpContent content = null);
        Dictionary<string, string> DefaultHeaders { get; }
        Task<INetResponse> DeleteAsync(string url);
        Task<INetResponse<TResponse>> DeleteJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> DeleteJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> DeleteAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> DeleteAsync(string url, HttpContent content);
        Task<INetResponse<TResponse>> GetAsync<TResponse>(string url);
        Task<INetResponse> HeadAsync(string url);
        Task<INetResponse> OptionsAsync(string url);
        Task<INetResponse<TResponse>> OptionsJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> OptionsJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> OptionsAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> OptionsAsync(string url, HttpContent content);
        Task<INetResponse> PatchAsync(string url);
        Task<INetResponse<TResponse>> PatchJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> PatchJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> PatchAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> PatchAsync(string url, HttpContent content);
        Task<INetResponse> PostAsync(string url);
        Task<INetResponse<TResponse>> PostJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> PostJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> PostAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> PostAsync(string url, HttpContent content);
        Task<INetResponse> PutAsync(string url);
        Task<INetResponse<TResponse>> PutJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> PutJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> PutAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> PutAsync(string url, HttpContent content);
        Task<INetResponse> TraceAsync(string url);
        Task<INetResponse<TResponse>> TraceJsonAsync<TRequest, TResponse>(string url, TRequest request);
        Task<INetResponse> TraceJsonAsync<TRequest>(string url, TRequest request);
        Task<INetResponse<TResponse>> TraceAsync<TResponse>(string url, HttpContent content);
        Task<INetResponse> TraceAsync(string url, HttpContent content);
    }
}