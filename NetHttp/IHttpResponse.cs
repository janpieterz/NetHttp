using System.Net;

namespace NetHttp
{
    public interface IHttpResponse
    {        
        string Content { get; set; }
        HttpStatusCode StatusCode { get; set; }
        bool IsSuccessful { get; }
    }
    public interface IHttpResponse<T> : IHttpResponse
    {
        T Data { get; set; }
    }
}
