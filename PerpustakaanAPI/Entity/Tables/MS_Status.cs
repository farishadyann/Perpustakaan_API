
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("MS_Status")]
    public class MS_Status
    {
        [Key]
        public int? StatusID_FK { get; set; }
        public string StatusName { get; set; }
    }
}
