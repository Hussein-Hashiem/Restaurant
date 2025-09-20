
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Item
    {
        [Key]
        public int item_id { get; private set; }
        public string name { get; private set; }
        public decimal price { get; private set; }
        public string description { get; private set; }
        public string imagepath { get; private set; }
        [ForeignKey("Menu")]
        public int menu_id { get; private set; }
        public Menu Menu { get; private set; }
        public bool recommended { get; private set; }
        public List<ReservedItem> ReservedItems { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
