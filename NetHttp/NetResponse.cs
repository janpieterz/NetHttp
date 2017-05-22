using System;
using System.Net;

namespace NetHttp
{
    public class NetResponse : INetResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class NetResponse<T> : NetResponse, INetResponse<T>
    {
        public T Data { get; set; }
    }
}
