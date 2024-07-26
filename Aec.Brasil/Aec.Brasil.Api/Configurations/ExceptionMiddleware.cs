using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Aec.Brasil.Api.Configurations
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        //private static void HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //}

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                Message = "An unexpected error occurred.",
                Detail = exception.Message,
                StackTrace = exception.StackTrace
            };

            var errorJson = System.Text.Json.JsonSerializer.Serialize(errorResponse);

            await context.Response.WriteAsync(errorJson);
        }
    }
}