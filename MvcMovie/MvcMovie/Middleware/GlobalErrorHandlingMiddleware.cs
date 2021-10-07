using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MvcMovie.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                // Step1: 處理Exception(記Log或其他)
                // Step2: 回傳統一結構Result
                await context.Response
                .WriteAsync($"{GetType().Name} catch exception. Message: {ex.Message}");

            }
        }
    }
}
