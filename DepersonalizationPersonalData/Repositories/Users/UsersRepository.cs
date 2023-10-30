using Dapper;
using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using Microsoft.Extensions.Logging;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DepersonalizationPersonalData.Repositories.Users
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly ILogger<UsersRepository> _logger;
        private readonly PostgresDatabaseFactory _postgresDatabaseFactory;

        public UsersRepository(ILogger<UsersRepository> logger, PostgresDatabaseFactory postgresDatabaseFactory)
        {
            _logger = logger;
            _postgresDatabaseFactory = postgresDatabaseFactory;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = $@"
SELECT
    User_id as {nameof(User.User_id)},
    Login as {nameof(User.Login)},
    Password as {nameof(User.Password)},
    FirstName as {nameof(User.FirstName)},
    LastName as {nameof(User.LastName)},
    Uname as {nameof(User.UName)},
    DEdit as {nameof(User.DEdit)}
FROM
    users;
".Trim();
            return await GetFromDatabase(query);
        }

        public async Task<IEnumerable<User>> GetUserById(Guid guid)
        {
            var query = $@"
SELECT
    User_id as {nameof(User.User_id)},
    Login as {nameof(User.Login)},
    Password as {nameof(User.Password)},
    FirstName as {nameof(User.FirstName)},
    LastName as {nameof(User.LastName)},
    Uname as {nameof(User.UName)},
    DEdit as {nameof(User.DEdit)}
FROM
    users
WHERE
    User_id={guid};
".Trim();
            return await GetFromDatabase(query);
        }

        public async Task<IEnumerable<User>> GetFromDatabase(string query)
        {
            using (var connection = await _postgresDatabaseFactory.Open())
            {
                try
                {
                    var result = await connection.QueryAsync<User>(query);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Возникла ошибка при получении пользователй из базы. {ex}", ex);
                }
                return new List<User>();
            }
        }

        public async Task<IEnumerable<User>> SignUp(string login, string password)
        {
            var parameters = new { Login = login, Password = password };
            var query = $@"
SELECT
    ""User_id"" as {nameof(User.User_id)},
    ""Login"" as {nameof(User.Login)},
    ""Password"" as {nameof(User.Password)},
    ""FirstName"" as {nameof(User.FirstName)},
    ""LastName"" as {nameof(User.LastName)},
    ""UName"" as {nameof(User.UName)},
    ""DEdit"" as {nameof(User.DEdit)}
FROM
    users
WHERE
    ""Login""=@Login
    and ""Password""=@Password;
".Trim();
            using (var connection = await _postgresDatabaseFactory.Open())
            {
                try
                {
                    var result = await connection.QueryAsync<User>(query, parameters);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Возникла ошибка при получении пользователй из базы. {ex}", ex);
                }
                return new List<User>();
            }
        }
    }
}
