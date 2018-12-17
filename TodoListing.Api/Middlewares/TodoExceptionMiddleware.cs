using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListing.Api.Middlewares
{
    public class TodoExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TodoExceptionMiddleware> _logger;

        public TodoExceptionMiddleware(RequestDelegate next, ILogger<TodoExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var resp = new 
                {
                    StatusCode = "500",
                    Description = "An Error occured"
                };

                var json = JsonConvert.SerializeObject(resp);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
