using System;
using System.Net;
using System.Threading.Tasks;
using Aec.Brasil.Data;
using Aec.Brasil.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        //private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        //{
        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //    context.Response.ContentType = "application/json";

        //    var errorResponse = new
        //    {
        //        Message = "An unexpected error occurred.",
        //        Detail = exception.Message,
        //        StackTrace = exception.StackTrace
        //    };

        //    var errorJson = System.Text.Json.JsonSerializer.Serialize(errorResponse);

        //    await context.Response.WriteAsync(errorJson);
        //}

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var dbContext = context.RequestServices.GetRequiredService<AecBrasilContext>();
            var logErro = new Domain.Entities.LogErro("usuario.generico")
            {
                Id = Guid.NewGuid(),
                Message = "An unexpected error occurred.",
                Detail = exception.Message,
                StackTrace = exception.StackTrace,
                Timestamp = DateTime.UtcNow
            };
            dbContext.LogErro.Add(logErro);
            await dbContext.SaveChangesAsync();
        }
    }
}