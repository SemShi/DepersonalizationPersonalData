namespace DepersonalizationPersonalData.Models
{
    public class UserPermission
    {
        public Guid User_id { get; set; }
        
        public int Permission_id { get; set; }
        
        public string UName { get; set; }
        
        public DateTime DEdit { get; set; }

    }
}
