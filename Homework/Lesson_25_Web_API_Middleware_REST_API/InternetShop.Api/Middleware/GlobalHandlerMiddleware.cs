using CorrelationId.Abstractions;
using Newtonsoft.Json;

namespace InternetShop.Api.Middleware
{
    public class GlobalHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment hostEnvironment, ILoggerFactory loggerFactory)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HaldleExceptionAsync(ex, httpContext, hostEnvironment, loggerFactory.CreateLogger(ex.Source));
            }
        }

        private Task HaldleExceptionAsync(Exception ex, HttpContext httpContext,
            IWebHostEnvironment hostEnvironment, ILogger logger)
        {
            var statusCode = StatusCodes.Status500InternalServerError;

            logger?.LogError(ex, $"Error message:{ex.Message}");

            var result = hostEnvironment.IsDevelopment() ?
                JsonConvert.SerializeObject(new { error = ex.Message, stackTrace = ex.StackTrace}, 
                                            Formatting.None, 
                                            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }) :
                JsonConvert.SerializeObject(new { error = $"Error occured during processing your request!"});

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            return httpContext.Response.WriteAsync(result);
        }
    }
}
