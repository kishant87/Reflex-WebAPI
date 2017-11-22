using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Xpanxion.Reflex.API.Web.Repository;
using System.Threading.Tasks;

namespace Xpanxion.Reflex.API.Web.Middleware
{
    public class AuthTokenValidatorMiddleware
    {
        private readonly RequestDelegate _next;
        private IAuthTokenRepository AuthRepo { get; set; }

        public AuthTokenValidatorMiddleware(RequestDelegate next, IAuthTokenRepository _repo)
        {
            _next = next;
            AuthRepo = _repo;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains("auth-token"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("Authentication Token is missing");
                return;
            }
            else
            {
                if (!AuthRepo.CheckValidAuthToken(context.Request.Headers["auth-token"]))
                {
                    context.Response.StatusCode = 401; //UnAuthorized
                    await context.Response.WriteAsync("Invalid Authentication Token");
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }

    #region ExtensionMethod
    public static class AuthTokenValidatorExtension
    {
        public static IApplicationBuilder UseAuthTokenValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<AuthTokenValidatorMiddleware>();
            return app;
        }
    }
    #endregion
}
