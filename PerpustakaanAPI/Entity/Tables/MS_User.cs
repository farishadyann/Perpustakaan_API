using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("MS_User")]
    public class MS_User
    {
        [Key]
        public int? UserID_PK { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? UserRoleID_FK { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
