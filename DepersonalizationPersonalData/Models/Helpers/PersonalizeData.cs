namespace DepersonalizationPersonalData.Models.Helpers
{
    public class PersonalizeData
    {
        public PersonalizeData(PersonalizeDataFirstTbl firstTbl)
        {
            Data_id = firstTbl.Data_id;
            FirstName = firstTbl.FirstName;
            MiddleName = firstTbl.MiddleName;
            LastName = firstTbl.LastName;
            Birthday = firstTbl.Birthday;
        }
        public PersonalizeData
        (
            PersonalizeDataFirstTbl firstTbl, 
            PersonalizeDataSecondTbl secondTbl,
            PersonalizeDataThirdTbl thirdTbl
        )
        {
            Data_id = firstTbl.Data_id;
            FirstName = firstTbl.FirstName;
            MiddleName = firstTbl.MiddleName;
            LastName = firstTbl.LastName;
            Birthday = firstTbl.Birthday;
            Country = secondTbl.Country;
            Area = secondTbl.Area;
            City = secondTbl.City;
            Phone = secondTbl.Phone;
            Street = thirdTbl.Street;
            Home = thirdTbl.Home;
            Building = thirdTbl.Building;
            Flat = thirdTbl.Flat;
        }
        public Guid Data_id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string? Country { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public int? Home { get; set; }
        public string? Building { get; set; }
        public int? Flat { get; set; }
    }
}
