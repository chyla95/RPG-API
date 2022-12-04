using RPG.API.Management.Utilities.Wrappers;
using RPG.Domain.Model.General;

namespace RPG.API.Management.Utilities
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
