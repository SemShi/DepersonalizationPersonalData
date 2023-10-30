using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepersonalizationPersonalData.Models;

namespace DepersonalizationPersonalData.Repositories.DcPermissions
{
    public interface IDcPermissionsRepository
    {
        Task<IEnumerable<Permission>> GetAllPermissions();
    }
}
