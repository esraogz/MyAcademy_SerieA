using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace SerieA.WebApi.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException && exception is not BadRequestException)
            {
                return false;
            }
            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound, //404
                BadRequestException => (int)HttpStatusCode.BadRequest, //400
            };

            await httpContext.Response.WriteAsJsonAsync(new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message
            }, cancellationToken);

            return true;
        }
    }
}
