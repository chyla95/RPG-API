using RPG.API.Public.Utilities.Wrappers;
using RPG.Domain.Model.General;

namespace RPG.API.Public.Utilities
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextWrapper _httpContextWrapper;

        public CurrentUser(IHttpContextWrapper httpContextWrapper)
        {
            _httpContextWrapper = httpContextWrapper;
        }

        public Staff GetCurrentUser()
        {
            Staff? user = _httpContextWrapper.GetFeature<Staff>();
            if (user == null) throw new Exception("Could not access current user data!");

            return user;
        }
    }
}
