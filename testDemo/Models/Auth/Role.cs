using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testDemo.Models.Auth
{
    public class Role
    {
        [Key]
        public Guid  ID { get; set; }
        public string Code { get; set; }
    }
}
