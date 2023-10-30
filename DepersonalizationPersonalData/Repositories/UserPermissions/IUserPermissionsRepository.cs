using DepersonalizationPersonalData.Models;

namespace DepersonalizationPersonalData.Repositories.UserPermissions
{
    public interface IUserPermissionsRepository
    {
        Task<IEnumerable<UserPermission>> GetUserPermissions(Guid guid);
    }
}
