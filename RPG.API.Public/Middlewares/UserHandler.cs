using System.Security.Claims;
using RPG.Application.Services;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.General;

namespace RPG.API.Public.Middlewares
{
    public class UserHandler
    {
        private readonly RequestDelegate _next;

        public UserHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IStaffService staffService)
        {
            string userIdClaimValue = httpContext.User.FindFirstValue("userId");
            if (!string.IsNullOrEmpty(userIdClaimValue))
            {
                int userId = int.Parse(userIdClaimValue);
                Staff? staff = await staffService.GetOne(userId);
                if (staff == null) throw new HttpNotFoundException($"User with ID of {userId} does not exist!");

                httpContext.Features.Set(staff);
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserHandlerExtensions
    {
        public static IApplicationBuilder UseUserHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserHandler>();
        }
    }
}
