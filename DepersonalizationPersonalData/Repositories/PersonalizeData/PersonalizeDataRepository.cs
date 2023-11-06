using Dapper;
using DepersonalizationPersonalData.Models;
using DepersonalizationPersonalData.Serivces.DatabaseService;
using Microsoft.Extensions.Logging;
using System.Text;

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

        public async Task<IEnumerable<Models.Helpers.PersonalizeData>> GetAllPeronalizeData(Guid guid, bool allData)
        {
            var firstTbl = await GetAllPeronalizeDataFirstTbl(guid == Guid.Empty ? Guid.Empty : guid) as List<PersonalizeDataFirstTbl>;
            if (!allData)
            {
                if (!firstTbl!.Any()) return new List<Models.Helpers.PersonalizeData>();
                var res = new List<Models.Helpers.PersonalizeData>();
                for (int i = 0; i < firstTbl!.Count(); i++)
                {
                    res.Add(new Models.Helpers.PersonalizeData(firstTbl![i]));
                }
                return res;
            }
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
    ""Data_id"" as {nameof(PersonalizeDataFirstTbl.Data_id)},
    ""FirstName"" as {nameof(PersonalizeDataFirstTbl.FirstName)},
    ""MiddleName"" as {nameof(PersonalizeDataFirstTbl.MiddleName)},
    ""LastName"" as {nameof(PersonalizeDataFirstTbl.LastName)},
    ""Birthday"" as {nameof(PersonalizeDataFirstTbl.Birthday)}
FROM
    ""personalize_data_tbl1""
{(guid == Guid.Empty ? "" : $" WHERE \"Data_id\"={guid} ")}
ORDER BY
    ""Data_id""
".Trim();
            return await GetFromDatabase<PersonalizeDataFirstTbl>(query);
        }

        public async Task<IEnumerable<PersonalizeDataSecondTbl>> GetAllPeronalizeDataSecondTbl(Guid guid)
        {
            var query = $@"
SELECT
    ""Data_id"" as {nameof(PersonalizeDataSecondTbl.Data_id)},
    ""Country"" as {nameof(PersonalizeDataSecondTbl.Country)},
    ""Area"" as {nameof(PersonalizeDataSecondTbl.Area)},
    ""City"" as {nameof(PersonalizeDataSecondTbl.City)},
    ""Phone"" as {nameof(PersonalizeDataSecondTbl.Phone)}
FROM
    ""personalize_data_tbl2""
{(guid == Guid.Empty ? "" : $" WHERE \"Data_id\"={guid} ")}
ORDER BY
    ""Data_id""
".Trim();
            return await GetFromDatabase<PersonalizeDataSecondTbl>(query);
        }

        public async Task<IEnumerable<PersonalizeDataThirdTbl>> GetAllPeronalizeDataThirdTbl(Guid guid)
        {
            var query = $@"
SELECT
    ""Data_id"" as {nameof(PersonalizeDataThirdTbl.Data_id)},
    ""Street"" as {nameof(PersonalizeDataThirdTbl.Street)},
    ""Home"" as {nameof(PersonalizeDataThirdTbl.Home)},
    ""Building"" as {nameof(PersonalizeDataThirdTbl.Building)},
    ""Flat"" as {nameof(PersonalizeDataThirdTbl.Flat)}
FROM
    ""personalize_data_tbl3""
{(guid == Guid.Empty ? "" : $" WHERE \"Data_id\"={guid} ")}
ORDER BY
    ""Data_id""
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

        public async Task<bool> InsertPersonaliezeData(Models.Helpers.PersonalizeData updateModel)
        {
            var queries = new List<string>();
            var queryTbl1 = $@"
INSERT INTO 
    ""personalize_data_tbl1"" (""Data_id"", ""FirstName"", ""MiddleName"", ""LastName"", ""Birthday"")
VALUES (
    {updateModel.Data_id},
    '{updateModel.FirstName}',
    '{updateModel.MiddleName}',
    '{updateModel.LastName}',
    '{updateModel.Birthday}')
".Trim();
            var queryTbl2 = $@"
INSERT INTO 
    ""personalize_data_tbl2"" (""Data_id"", ""Country"", ""Area"", ""City"", ""Phone"")
VALUES (
    {updateModel.Data_id},
    '{updateModel.Country}',
    '{updateModel.Area}',
    '{updateModel.City}',
    '{updateModel.Phone}')
".Trim();
            var queryTbl3 = $@"
INSERT INTO 
    ""personalize_data_tbl3"" (""Data_id"", ""Street"", ""Home"", ""Building"", ""Flat"")
VALUES (
    {updateModel.Data_id},
    '{updateModel.Street}',
    {updateModel.Home},
    '{updateModel.Building}',
    {updateModel.Flat})
".Trim();

            queries.Add(queryTbl1);
            queries.Add(queryTbl2);
            queries.Add(queryTbl3);

            using (var connection = await _postgresDatabaseFactory.Open())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var query in queries)
                        await connection.ExecuteAsync(query);
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError("Возникла ошибка при занесении персональных данных в базу. {ex}", ex);
                }
                return false;
            }
        }

        public async Task<bool> UpdatePersonaliezeData(Models.Helpers.PersonalizeData updateModel, Dictionary<string, bool> fields)
        {
            var queries = new List<string>();
            var queryTbl1 = $@"
UPDATE 
    ""personalize_data_tbl1""
SET
    {GetFieldsSQL("personalize_data_tbl1", updateModel, fields, out bool tbl1HasZeroFields)}
WHERE
    ""Data_id"" = '{updateModel.Data_id}'
".Trim();
            var queryTbl2 = $@"
UPDATE 
    ""personalize_data_tbl2""
SET
    {GetFieldsSQL("personalize_data_tbl2", updateModel, fields, out bool tbl2HasZeroFields)}
WHERE
    ""Data_id"" = '{updateModel.Data_id}'
".Trim();
            var queryTbl3 = $@"
UPDATE 
    ""personalize_data_tbl3""
SET
    {GetFieldsSQL("personalize_data_tbl3", updateModel, fields, out bool tbl3HasZeroFields)}
WHERE
    ""Data_id"" = '{updateModel.Data_id}'
".Trim();
            if(!tbl1HasZeroFields)
                queries.Add(queryTbl1);
            if (!tbl2HasZeroFields)
                queries.Add(queryTbl2);
            if (!tbl3HasZeroFields)
                queries.Add(queryTbl3);


            using (var connection = await _postgresDatabaseFactory.Open())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var query in queries)
                        await connection.ExecuteAsync(query);
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.LogError("Возникла ошибка при занесении персональных данных в базу. {ex}", ex);
                }
                return false;
            }
        }

        private string GetFieldsSQL(string tbl, Models.Helpers.PersonalizeData updateModel, Dictionary<string, bool> fields, out bool zeroFields) 
        {
            zeroFields = false;
            var sb = new StringBuilder();
            var listOfFields = new List<string>();
            switch(tbl)
            {
                case "personalize_data_tbl1":
                    listOfFields
                        .AddRange(fields
                            .Where(key =>
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.FirstName)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.LastName)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.MiddleName)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Birthday)}")
                            .Where(val => val.Value == true)
                            .Select(key => key.Key)
                            );
                    
                    break;
                case "personalize_data_tbl2":
                    listOfFields
                        .AddRange(fields
                            .Where(key =>
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Country)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Area)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.City)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Phone)}")
                            .Where(val => val.Value == true)
                            .Select(key => key.Key)
                            );
                    break;
                case "personalize_data_tbl3":
                    listOfFields
                        .AddRange(fields
                            .Where(key =>
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Street)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Home)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Building)}" ||
                                key.Key == $"{nameof(Models.Helpers.PersonalizeData.Flat)}")
                            .Where(val => val.Value == true)
                            .Select(key => key.Key)
                            );
                    break;
            }

            int fieldCount = listOfFields.Count();
            if( fieldCount == 0 ) 
            {
                zeroFields = true;
                return "";
            }
            if (fieldCount == 1) return $@"""{listOfFields[0]}"" = {updateModel.GetFieldByName(listOfFields[0])}";

            int counter = 0;
            foreach (var field in listOfFields)
            {
                counter++;
                sb.Append($@"""{field}"" = {updateModel.GetFieldByName(field)}");
                if (counter + 1 <= fieldCount)
                    sb.Append(", " + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
