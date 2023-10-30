using Dapper;
using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using Microsoft.Extensions.Logging;

namespace DepersonalizationPersonalData.Repositories.UserPermissions
{
    public class UserPermissionsRepository : IUserPermissionsRepository
    {
        private readonly ILogger<UserPermissionsRepository> _logger;
        private readonly PostgresDatabaseFactory _postgresDatabaseFactory;

        public UserPermissionsRepository(ILogger<UserPermissionsRepository> logger, PostgresDatabaseFactory postgresDatabaseFactory)
        {
            _logger = logger;
            _postgresDatabaseFactory = postgresDatabaseFactory;
        }

        public async Task<IEnumerable<UserPermission>> GetUserPermissions(Guid guid)
        {
            var query = $@"
SELECT
    ""User_id"" as {nameof(UserPermission.User_id)},
    ""Permission_id"" as {nameof(UserPermission.Permission_id)},
    ""UName"" as {nameof(UserPermission.UName)},
    ""DEdit"" as {nameof(UserPermission.DEdit)}
WHERE
    ""User_id""={guid}
".Trim();

            using (var connection = await _postgresDatabaseFactory.Open())
            {
                try
                {
                    var result = await connection.QueryAsync<UserPermission>(query);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Возникла ошибка при получении прав пользователей из базы. {ex}", ex);
                }
                return new List<UserPermission>();
            }
        }

    }
}
