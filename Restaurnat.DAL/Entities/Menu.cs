
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Menu
    {
        [Key]
        public int nenu_id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public int num_of_items { get; set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Item> Items { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
