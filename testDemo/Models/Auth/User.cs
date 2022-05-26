using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testDemo.Models.Auth
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid  ID { get; set; }
        public  string UserName{ get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    
    }
 
}
