using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NewsApi.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                // Agregar información contextual a los logs
                Log.Error(ex, "An unhandled exception occurred while processing the request. " +
                                "Request Method: {Method}, Request Path: {Path}, Status Code: {StatusCode}",
                                context.Request.Method, context.Request.Path, context.Response.StatusCode);

                // Captura la excepción y devuelve una respuesta adecuada
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    message = "An error occurred while processing your request.",
                    detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}
