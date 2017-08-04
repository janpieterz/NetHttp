using System;
using System.Net;
using System.Net.Http.Headers;

namespace NetHttp
{
    public class HttpResponse : IHttpResponse
    {
        public string Content { get; set; }
        private HttpStatusCode _statusCode;
        public HttpStatusCode StatusCode
        {
            get => _statusCode;
            set
            {
                _statusCode = value;
                if ((int)_statusCode < 200 || (int)_statusCode > 299)
                {
                    IsSuccessful = false;
                }
                else
                {
                    IsSuccessful = true;
                }
            }
        }
        public bool IsSuccessful { get; private set; }
        private Exception _exception;
        public Exception Exception
        {
            get => _exception;
            set
            {
                _exception = value;
                IsSuccessful = false;
            }
        }
        public HttpResponseHeaders Headers { get; set; }
    }
    public class HttpResponse<T> : HttpResponse, IHttpResponse<T>
    {
        public T Data { get; set; }
    }
}
