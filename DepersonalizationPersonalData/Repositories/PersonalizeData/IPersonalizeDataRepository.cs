using DepersonalizationPersonalData.Models;

namespace DepersonalizationPersonalData.Repositories.PersonalizeData
{
    public interface IPersonalizeDataRepository
    {
        Task<IEnumerable<Models.Helpers.PersonalizeData>> GetAllPeronalizeData(Guid guid);
        Task<IEnumerable<PersonalizeDataFirstTbl>> GetAllPeronalizeDataFirstTbl(Guid guid);
        Task<IEnumerable<PersonalizeDataSecondTbl>> GetAllPeronalizeDataSecondTbl(Guid guid);
        Task<IEnumerable<PersonalizeDataThirdTbl>> GetAllPeronalizeDataThirdTbl(Guid guid);
        Task<IEnumerable<T>> GetFromDatabase<T>(string query);
    }
}
