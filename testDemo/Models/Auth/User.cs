namespace testDemo.Models.Auth
{
    public class User 
    {
        public string  ID { get; set; }
        public  string UserName{ get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    
    }
 
}
