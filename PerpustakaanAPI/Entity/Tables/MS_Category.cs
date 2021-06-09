

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerpustakaanAPI.Entity.Tables
{
    [Table("MS_Category")]
    public class MS_Category
    {
        [Key]
        public int? CategoryID_PK { get; set; }
        public string Category { get; set; }
    }
}
