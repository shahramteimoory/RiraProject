using Rira.Common.Utilities;
using System.Net;

namespace Rira.Common.Dto
{
    public record ApiResult
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new();
        public HttpStatusCode StatusCode { get; set; }

        public static ApiResult Success(string message = AlertConstats.TaskSuccess) =>
            new() { IsSuccess = true, StatusCode = HttpStatusCode.OK, Messages = [message] };

        public static ApiResult Created(string message = AlertConstats.TaskCreated) =>
            new() { IsSuccess = true, StatusCode = HttpStatusCode.Created, Messages = [message] };

        public static ApiResult BadRequest(string message = AlertConstats.BadRequestMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Messages = [message] };

        public static ApiResult Conflict(string message = AlertConstats.ConflictMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.Conflict, Messages = [message] };

        public static ApiResult InternalServerError(string message = AlertConstats.InternalServerErrorMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Messages = [message] };

        public static ApiResult NotFound(string message = AlertConstats.NotFound) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Messages = [message] };
    }
    public record ApiResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new();
        public HttpStatusCode StatusCode { get; set; }

        public static ApiResult<T> Success(T data, string message = AlertConstats.TaskSuccess) =>
            new() { IsSuccess = true, StatusCode = HttpStatusCode.OK, Data = data, Messages = [message] };

        public static ApiResult<T> Created(T data, string message = AlertConstats.TaskCreated) =>
            new() { IsSuccess = true, StatusCode = HttpStatusCode.Created, Data = data, Messages = [message] };

        public static ApiResult<T> BadRequest(string message = AlertConstats.BadRequestMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Messages = [message] };

        public static ApiResult<T> Conflict(string message = AlertConstats.ConflictMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.Conflict, Messages = [message] };

        public static ApiResult<T> InternalServerError(string message = AlertConstats.InternalServerErrorMessage) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.InternalServerError, Messages = [message] };

        public static ApiResult<T> NotFound(string message = AlertConstats.NotFound) =>
            new() { IsSuccess = false, StatusCode = HttpStatusCode.NotFound, Messages = [message] };
    }
}
