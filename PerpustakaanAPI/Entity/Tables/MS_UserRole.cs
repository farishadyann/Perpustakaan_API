using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("MS_UserRole")]
    public class MS_UserRole
    {
        [Key]
        public int? UserRoleID_PK { get; set; }
        public string UserRoleName { get; set; }
    }
}
