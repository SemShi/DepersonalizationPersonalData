using Dapper;
using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using Microsoft.Extensions.Logging;

namespace DepersonalizationPersonalData.Repositories.PersonalizeData
{
    public class PersonalizeDataRepository : IPersonalizeDataRepository
    {
        private readonly ILogger<PersonalizeDataRepository> _logger;
        private readonly PostgresDatabaseFactory _postgresDatabaseFactory;

        public PersonalizeDataRepository(ILogger<PersonalizeDataRepository> logger, PostgresDatabaseFactory postgresDatabaseFactory)
        {
            _logger = logger;
            _postgresDatabaseFactory = postgresDatabaseFactory;
        }

        public async Task<IEnumerable<Models.Helpers.PersonalizeData>> GetAllPeronalizeData(Guid guid)
        {
            var firstTbl = await GetAllPeronalizeDataFirstTbl(guid == Guid.Empty ? Guid.Empty : guid) as List<PersonalizeDataFirstTbl>;
            var secondTbl = await GetAllPeronalizeDataSecondTbl(guid == Guid.Empty ? Guid.Empty : guid) as List<PersonalizeDataSecondTbl>;
            var thirdTbl = await GetAllPeronalizeDataThirdTbl(guid == Guid.Empty ? Guid.Empty : guid) as List<PersonalizeDataThirdTbl>;

            if(!firstTbl!.Any() || !secondTbl!.Any() || !thirdTbl!.Any()) return new List<Models.Helpers.PersonalizeData>();
            
            var result = new List<Models.Helpers.PersonalizeData>();
            for(int i = 0; i < firstTbl!.Count(); i++)
            {
                result.Add(new Models.Helpers.PersonalizeData(firstTbl![i], secondTbl![i], thirdTbl![i]));
            }
            return result;
        }

        public async Task<IEnumerable<PersonalizeDataFirstTbl>> GetAllPeronalizeDataFirstTbl(Guid guid)
        {
            var query = $@"
SELECT
    Data_id as {nameof(PersonalizeDataFirstTbl.Data_id)},
    FirstName as {nameof(PersonalizeDataFirstTbl.FirstName)},
    MiddleName as {nameof(PersonalizeDataFirstTbl.MiddleName)},
    LastName as {nameof(PersonalizeDataFirstTbl.LastName)},
    Birthday as {nameof(PersonalizeDataFirstTbl.Birthday)}
FROM
    personalize_data_tbl1
{(guid == Guid.Empty ? "" : $" WHERE Data_id={guid} ")}
ORDER BY
    Data_id
".Trim();
            return await GetFromDatabase<PersonalizeDataFirstTbl>(query);
        }

        public async Task<IEnumerable<PersonalizeDataSecondTbl>> GetAllPeronalizeDataSecondTbl(Guid guid)
        {
            var query = $@"
SELECT
    Data_id as {nameof(PersonalizeDataSecondTbl.Data_id)},
    Country as {nameof(PersonalizeDataSecondTbl.Country)},
    Area as {nameof(PersonalizeDataSecondTbl.Area)},
    City as {nameof(PersonalizeDataSecondTbl.City)},
    Phone as {nameof(PersonalizeDataSecondTbl.Phone)}
FROM
    personalize_data_tbl2
{(guid == Guid.Empty ? "" : $" WHERE Data_id={guid} ")}
ORDER BY
    Data_id
".Trim();
            return await GetFromDatabase<PersonalizeDataSecondTbl>(query);
        }

        public async Task<IEnumerable<PersonalizeDataThirdTbl>> GetAllPeronalizeDataThirdTbl(Guid guid)
        {
            var query = $@"
SELECT
    Data_id as {nameof(PersonalizeDataThirdTbl.Data_id)},
    Street as {nameof(PersonalizeDataThirdTbl.Street)},
    Home as {nameof(PersonalizeDataThirdTbl.Home)},
    Building as {nameof(PersonalizeDataThirdTbl.Building)},
    Flat as {nameof(PersonalizeDataThirdTbl.Flat)}
FROM
    personalize_data_tbl3
{(guid == Guid.Empty ? "" : $" WHERE Data_id={guid} ")}
ORDER BY
    Data_id
".Trim();
            return await GetFromDatabase<PersonalizeDataThirdTbl>(query);
        }

        public async Task<IEnumerable<T>> GetFromDatabase<T>(string query)
        {
            using (var connection = await _postgresDatabaseFactory.Open())
            {
                try
                {
                    var result = await connection.QueryAsync<T>(query);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    _logger.LogError("Возникла ошибка при получении персональных данных из базы. {ex}", ex);
                }
                return new List<T>();
            }
        }
    }
}
