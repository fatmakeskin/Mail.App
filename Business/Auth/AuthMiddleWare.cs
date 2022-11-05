using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Auth
{
    public class AuthMiddleWare
    {
        private readonly RequestDelegate requestDelegete;
        public AuthMiddleWare(RequestDelegate _requestDelegate)
        {
                requestDelegete = _requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            try
            {
                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authHeader.Substring(6).Trim();
                    var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var credentials = credentialString.Split(':');
                    if (credentials[0] == "fatma" && credentials[1] == "123")
                    {
                        var claims = new[]
                        {
                            new Claim("name", credentials[0]),
                            new Claim(ClaimTypes.Role, "Admin")
                        };
                        var identity = new ClaimsIdentity(claims, "Basic");
                        context.User = new ClaimsPrincipal(identity);
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                }
            }
            catch
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            await requestDelegete(context);
        }
    }
}
