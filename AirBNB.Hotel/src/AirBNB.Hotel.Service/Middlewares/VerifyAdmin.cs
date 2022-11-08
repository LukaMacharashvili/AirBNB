using System.Net;
using System.Security.Claims;

namespace AirBNB.Hotels.Service.Middlewares
{
    public class VerifyAdmin
    {
        private readonly RequestDelegate _next;

        public VerifyAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var role = context.User.FindFirst(ClaimTypes.Role).Value;

            if (role == "Admin" || role == "Superadmin")
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