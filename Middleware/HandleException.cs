using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactManangement.Middleware
{
    public class HandleException
    {
        private readonly RequestDelegate _requestNext;
        public HandleException(RequestDelegate requestNext)
        {
            _requestNext = requestNext;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestNext(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/problem+json";
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetail = new ProblemDetails()
            {
                Type = "Exception",
                Title = "An error occured while proccessing your request",
                Detail = ex.Message,
                Status = StatusCodes.Status500InternalServerError,
            };

            InternalResponse _internalResponse = new()
            {
                Result = problemDetail,
                Message = ex.Message,
                IsSuccess = false,
            };


            var result = JsonConvert.SerializeObject(_internalResponse);
            await httpContext.Response.WriteAsync(result);
        }
    }
}
