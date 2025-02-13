using Exceptions;
using Newtonsoft.Json;


namespace back.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, AppException ex)
        {
            Console.WriteLine($"Application Error: {ex.Message}, Details: {ex.Details}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex.StatusCode;

            var response = new
            {
                message = ex.Message,
                details = ex.Details
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Console.WriteLine($"Unhandled Exception: {ex.Message}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new
            {
                message = "An unhandled exception has occurred.",
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));

        }
    }
}
