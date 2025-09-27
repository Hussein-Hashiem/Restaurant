
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class Table
    {
        [Key]
        public int table_id { get; private set; }
        public int capacity { get; private set; }
        public bool is_available { get; private set; }
        public List<ReservedTable> ReservedTables { get; private set; }
        public DateTime? CreatedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; set; } = false;
    }
}
