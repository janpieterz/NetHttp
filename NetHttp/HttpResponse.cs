using System.Net;

namespace NetHttp
{
    public class HttpResponse : IHttpResponse
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful => ((int)StatusCode >= 200) && ((int)StatusCode <= 299);
    }
    public class HttpResponse<T> : HttpResponse, IHttpResponse<T>
    {
        public T Data { get; set; }
    }
}
