using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace Boilerplate.Api.Middlewares
{
    public sealed class XsrfProtectionMiddleware
    {
        private readonly IAntiforgery _antiforgery;
        private readonly RequestDelegate _next;

        public XsrfProtectionMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Cookies.Append(
                ".AspNetCore.Xsrf",
                _antiforgery.GetAndStoreTokens(context).RequestToken,
                new CookieOptions {HttpOnly = false, Secure = true, MaxAge = TimeSpan.FromMinutes(60)});

            context.Response.Headers.TryAdd("X-Content-Type-Options", "nosniff");
            context.Response.Headers.TryAdd("X-Xss-Protection", "1");
            context.Response.Headers.TryAdd("X-Frame-Options", "DENY");
            
            await _next(context);
        }
    }
}