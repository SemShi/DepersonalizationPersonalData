using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Models.Helpers;

namespace DepersonalizationPersonalData.Repositories.PersonalizeData
{
    public interface IPersonalizeDataRepository
    {
        Task<IEnumerable<Models.Helpers.PersonalizeData>> GetAllPeronalizeData(Guid guid, bool allData);
        Task<IEnumerable<PersonalizeDataFirstTbl>> GetAllPeronalizeDataFirstTbl(Guid guid);
        Task<IEnumerable<PersonalizeDataSecondTbl>> GetAllPeronalizeDataSecondTbl(Guid guid);
        Task<IEnumerable<PersonalizeDataThirdTbl>> GetAllPeronalizeDataThirdTbl(Guid guid);
        Task<IEnumerable<T>> GetFromDatabase<T>(string query);

        Task<bool> UpdatePersonaliezeData(Models.Helpers.PersonalizeData updateModel, Dictionary<string, bool> fields);
        Task<bool> InsertPersonaliezeData(Models.Helpers.PersonalizeData updateModel);
    }
}
