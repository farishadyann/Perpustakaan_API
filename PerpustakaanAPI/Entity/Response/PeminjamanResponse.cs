using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpustakaanAPI.Entity.Response
{
    public class PeminjamanResponse
    {
        public int? PeminjamanID_PK { get; set; }
        public int? BookID_FK { get; set; }
        public string BookName { get; set; }
        public int? BookCategoryID_FK { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int? Stok { get; set; }
        public string Penerbit { get; set; }
        public string Penulis { get; set; }
        public string UserName { get; set; }
        public int? UserRoleID_FK { get; set; }
        public string UserRoleName { get; set; }
        public int? StatusID_FK { get; set; }
        public string AlamatPengiriman { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
