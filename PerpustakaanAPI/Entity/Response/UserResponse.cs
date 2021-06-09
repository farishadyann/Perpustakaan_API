using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpustakaanAPI.Entity.Response
{
    public class UserResponse
    {
        public int? UserID_PK { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? UserRoleID_FK { get; set; }
        public string UserRoleName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
