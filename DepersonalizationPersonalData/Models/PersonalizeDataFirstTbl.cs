namespace DepersonalizationPersonalData.Models
{
    public class PersonalizeDataFirstTbl
    {
        public Guid Data_id { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Birthday { get; set; }
    }
}
