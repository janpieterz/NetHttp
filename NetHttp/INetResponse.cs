using System;
using System.Net;

namespace NetHttp
{
    public interface INetResponse
    {        
        string Content { get; set; }
        HttpStatusCode StatusCode { get; set; }     
    }
    public interface INetResponse<T>
    {
        T Data { get; set; }
    }
}
