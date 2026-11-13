using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SerieA.WebApi.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var (statusCode, title) = exception switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, "Kayıt bulunamadı"),
                BadRequestException => (StatusCodes.Status400BadRequest, "Geçersiz istek"),
                _ => (0, null)
            };

            if (statusCode == 0) return false;

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = exception.Message
            }, options: null, contentType: "application/problem+json", cancellationToken);

            return true;
        }
    }

}
