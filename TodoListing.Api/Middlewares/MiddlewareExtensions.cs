using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListing.Api.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseTodoException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TodoExceptionMiddleware>();
        }
    }
}
