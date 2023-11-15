using FIAP.Reconecta.API.Exceptions;
using System.Data.Entity.Core;
using System.Net;
using System.Text.Json;

namespace FIAP.Reconecta.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException => (int)HttpStatusCode.NotFound,// not found error
                    ObjectNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.BadRequest,// unhandled error
                };
                var result = JsonSerializer.Serialize(new { message = error?.Message, innerExceptionMessage = error?.InnerException?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
