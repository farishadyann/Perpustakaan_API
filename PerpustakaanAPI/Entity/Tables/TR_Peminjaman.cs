using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("TR_Peminjaman")]
    public class TR_Peminjaman
    {
        [Key]
        public int? PeminjamanID_PK { get; set; }
        public int? BookID_FK { get; set; }
        public string UserName { get; set; }
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
