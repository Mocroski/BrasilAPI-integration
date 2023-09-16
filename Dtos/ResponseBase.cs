using System.Dynamic;
using System.Net;

namespace IntegraBrasilAPI.Dtos
{
    public class ResponseBase<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Data { get; set; }
        public ExpandoObject? Error { get; set; }
    }
}
