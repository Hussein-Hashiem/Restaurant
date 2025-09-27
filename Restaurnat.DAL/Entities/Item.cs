
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
        public DateTime? CreatedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public Item(string name, decimal price, string description, string imagepath, int menu_id, bool recommended)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.imagepath = imagepath;
            this.menu_id = menu_id;
            this.recommended = recommended;
            CreatedOn = DateTime.Now;
            CreatedBy = "System";
        }
        public void Update(string name, decimal price, string description, string imagepath, int menu_id, bool recommended)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.imagepath = imagepath;
            this.menu_id = menu_id;
            this.recommended = recommended;
            ModifiedOn = DateTime.Now;
            ModifiedBy = "System";
        }
    }
}
