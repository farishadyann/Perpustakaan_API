using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("MS_Books")]
    public class MS_Books
    {
        [Key]
        public int? BookID_PK { get; set; }
        public string BookName { get; set; }
        public int? BookCategoryID_FK { get; set; }
        public string Description { get; set; }
        public int? Stok { get; set; }
        public string Penerbit { get; set; }
        public string Penulis { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
