using System;
using System.Net;

namespace NetHttp
{
    public class HttpResponse : IHttpResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class HttpResponse<T> : HttpResponse, IHttpResponse<T>
    {
        public T Data { get; set; }
    }
}
