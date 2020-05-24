using DMCIT.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DMCIT.Web.Middleware
{
    public class MyExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILoggerFactory _logger;

        public MyExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                ILogger log = _logger.CreateLogger("Exception");
                log.LogError(e.Message);
                await HandleExceptionAsync(httpContext, e);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            var message = e.Message;
            var temp = e;
            var tempCount = 4;
            while (temp.InnerException != null && tempCount > 0)
            {
                temp = temp.InnerException;
                message += Environment.NewLine + temp.Message;
                tempCount--;
            }
            if (e is RepositoryException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    messages = new[] { e.Message },
                    stackTrace = e.StackTrace,
                    source = e.Source
                }));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    messages = new[] { e.Message },
                    stackTrace = e.StackTrace,
                    source = e.Source
                }));
            }
        }
    }
}
