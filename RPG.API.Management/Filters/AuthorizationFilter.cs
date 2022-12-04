using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using RPG.API.Management.Utilities;
using RPG.Domain.Exceptions;
using RPG.Domain.Model.General;
using System.Diagnostics;
using System.Net;

namespace RPG.API.Management.Filters
{
    public class AuthorizationFilter : IAsyncActionFilter, IAuthorizationFilter
    {
        private readonly ICurrentUser _currentUser;

        public IEnumerable<string>? Roles { get; set; }

        public AuthorizationFilter(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Staff? currentUser = _currentUser.GetCurrentUser();
            if(currentUser == null) throw new HttpUnauthorizedException("You are not signed in!");

            bool isAuthorized = false;
            if (Roles != null)
            {
                foreach (string role in Roles)
                {
                    if (currentUser.Roles.Any(r => r.Name == role))
                    {
                        isAuthorized = true;
                        break;
                    }
                }
            }
            else
            {
                isAuthorized = true;
            }

            if (isAuthorized) await next();
            else throw new HttpUnauthorizedException("You do not have sufficient role to access this endpoint!");
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine("   -> Auth triggered!");
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter, IFilterFactory
    {
        public bool IsReusable { get; set; } = false;
        public string? UserRoles { get; set; }



        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            AuthorizationFilter? authorizationFilter = serviceProvider.GetService<AuthorizationFilter>();
            if (authorizationFilter == null) throw new NullReferenceException(nameof(authorizationFilter));
            if (string.IsNullOrEmpty(UserRoles)) return authorizationFilter;

            IEnumerable<string> roles = UserRoles.Split(",").Select(r => r.Trim());
            authorizationFilter.Roles = roles;

            return authorizationFilter;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
