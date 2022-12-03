using System.Net;

namespace RPG.Domain.Exceptions
{
    public class HttpBadRequestException : HttpException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public HttpBadRequestException(string message = "Bad Request!") : base(message) { }
    }
}
