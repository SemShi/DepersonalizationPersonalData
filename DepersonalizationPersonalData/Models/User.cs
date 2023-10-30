namespace DepersonalizationPersonalData.Models
{
    public class User
    {
        public Guid User_id { get; set; }
        
        public string Login {  get; set; }
        
        public string Password {  get; set; }
        
        public string FirstName {  get; set; }
        
        public string LastName {  get; set; }
        
        public string UName {  get; set; }
        
        public DateTime DEdit {  get; set; }


    }
}
