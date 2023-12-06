using Newtonsoft.Json;
using Serilog;
using System.Net;
using System;

namespace Trolley.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionsAsnyc(httpContext, serviceProvider, ex);
            }
        }


        public static async Task HandleExceptionsAsnyc(HttpContext httpContext, IServiceProvider serviceProvider, Exception exception)
        {
            Log.Error(exception, "Unhandled exception occurred while processing the request");

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await httpContext.Response.WriteAsync(new
            {
                status = httpContext.Response.StatusCode,
                message = "Ein interner Serverfehler ist aufgetreten"
            }.ToString());
        }
    }
}
