
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class Table
    {
        [Key]
        public int table_id { get; set; }
        public int capacity { get; set; }
        public bool is_available { get; set; }
        public List<ReservedTable> ReservedTables { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
