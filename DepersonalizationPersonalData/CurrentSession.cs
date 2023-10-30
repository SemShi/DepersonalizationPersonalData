using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Models.Helpers;
using DepersonalizationPersonalData.Repositories.UserPermissions;
using DepersonalizationPersonalData.Repositories.Users;
using Microsoft.Extensions.Logging;

namespace DepersonalizationPersonalData
{
    public class CurrentSession
    {
        private readonly ILogger<CurrentSession> _logger;
        private readonly IUsersRepository _usersRepository;
        private readonly IUserPermissionsRepository _userPermissionsRepository;
        

        public CurrentSession(ILogger<CurrentSession> logger, IUsersRepository usersRepository, IUserPermissionsRepository userPermissionsRepository)
        {
            _logger = logger;
            _usersRepository = usersRepository;
            _userPermissionsRepository = userPermissionsRepository;
        }

        public UserInfo? CurrentUser { get; set; }
        public bool IsActive { get; private set; }

        public async Task<(bool, string)> ActivateSession(string login, string password)
        {
            string message = string.Empty;
            if (IsActive) 
            {
                message = "Сессия уже активна.";
                return (false, message);
            } 
            var user = await _usersRepository.SignUp(login, password) as List<User>;
            if (!user!.Any()) 
            {
                message = "Пользователь с таким логином или паролем не найден в системе.";
                return (false, message); ;
            } 
            var permissions = await _userPermissionsRepository.GetUserPermissions(user[0].User_id) as List<UserPermission>;
            CurrentUser = new UserInfo(user[0], permissions!);
            IsActive = true;
            return (true, message);
        }

        public bool DeActivateSession()
        {
            if (!IsActive) return false;
            IsActive = false;
            CurrentUser = null;
            return true;
        }

        
    }
}
