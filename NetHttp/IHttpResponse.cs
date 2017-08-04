using System;
using System.Net;
using System.Net.Http.Headers;

namespace NetHttp
{
    public interface IHttpResponse
    {        
        string Content { get; }
        HttpStatusCode StatusCode { get; }
        bool IsSuccessful { get; }
        Exception Exception { get; }
        HttpResponseHeaders Headers { get; }
    }
    public interface IHttpResponse<T> : IHttpResponse
    {
        T Data { get; }
    }
}
