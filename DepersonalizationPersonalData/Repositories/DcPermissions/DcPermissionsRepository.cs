using Dapper;
using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using Microsoft.Extensions.Logging;

namespace DepersonalizationPersonalData.Repositories.DcPermissions
{
    public class DcPermissionsRepository : IDcPermissionsRepository
    {
        private readonly ILogger<DcPermissionsRepository> _logger;
        private readonly PostgresDatabaseFactory _postgresDatabaseFactory;

        public DcPermissionsRepository(ILogger<DcPermissionsRepository> logger, PostgresDatabaseFactory postgresDatabaseFactory)
        {
            _logger = logger;
            _postgresDatabaseFactory = postgresDatabaseFactory;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissions()
        {
            var query = $@"
SELECT
    Permission_id as {nameof(Permission.Permission_id)},
    Name as {nameof(Permission.Permission_id)},
    Description as {nameof(Permission.Description)},
    UName as {nameof(Permission.UName)},
    DEdit as {nameof(Permission.DEdit)}
FROM
    dc_permissions
".Trim();
            using (var connection = await _postgresDatabaseFactory.Open())
            {
                try
                {
                    var result = await connection.QueryAsync<Permission>(query);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Возникла ошибка при получении прав из базы. {ex}", ex);
                }
                return new List<Permission>();
            }
        }
    }
}
