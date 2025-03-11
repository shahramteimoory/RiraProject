using System.Net;

namespace Rira.Common.Dto
{
    public record ApiResult
    {
        public bool IsSuccess { get; set; }
        public List<string>? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public record ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string>? Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
