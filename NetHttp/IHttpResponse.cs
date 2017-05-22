using System.Net;

namespace NetHttp
{
    public interface IHttpResponse
    {        
        string Content { get; set; }
        HttpStatusCode StatusCode { get; set; }     
    }
    public interface IHttpResponse<T>
    {
        T Data { get; set; }
    }
}
