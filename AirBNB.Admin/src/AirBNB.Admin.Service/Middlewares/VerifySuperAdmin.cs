using System.Net;
using System.Security.Claims;

namespace AirBNB.Admin.Service.Middlewares
{
    public class VerifySuperAdmin
    {
        private readonly RequestDelegate _next;

        public VerifySuperAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var role = context.User.FindFirst(ClaimTypes.Role).Value;

            if (role == "Superadmin")
            {
                await _next(context);
            }
            else
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Not Allowed");
            }

        }
    }
}