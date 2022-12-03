using System.Net;

namespace RPG.Domain.Exceptions
{
    public class HttpNotFoundException : HttpException
    {
        public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

        public HttpNotFoundException(string message = "Not Found!") : base(message) { }
    }
}
