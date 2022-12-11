using RPG.API.Public.Utilities.Wrappers;
using RPG.Domain.Model.Game;
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

        public Player GetCurrentUser()
        {
            Player? user = _httpContextWrapper.GetFeature<Player>();
            if (user == null) throw new Exception("Could not access current user data!");

            return user;
        }
    }
}
