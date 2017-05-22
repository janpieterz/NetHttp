using System;
using System.Net;

namespace NetHttp
{
    public interface IHttpResponse
    {        
        string Content { get; }
        HttpStatusCode StatusCode { get; }
        bool IsSuccessful { get; }
        Exception Exception { get; }
    }
    public interface IHttpResponse<T> : IHttpResponse
    {
        T Data { get; }
    }
}
