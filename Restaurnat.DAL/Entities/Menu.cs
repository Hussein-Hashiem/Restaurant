
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Menu
    {
        [Key]
        public int menu_id { get; private set; }
        public string name { get; private set; }
        public string Description { get; private set; }
        public int num_of_items { get; private set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public List<Item> Items { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public Menu()
        {
            
        }
        public Menu(
            string name,
            string description,
            int numOfItems,
            int restaurantId,
            string createdBy,
            DateTime createdOn,
            DateTime? modifiedOn,
            string? modifiedBy,
            DateTime? deletedOn,
            string? deletedBy,
            bool isDeleted
        )
        {
            this.name = name;
            this.Description = description;
            this.num_of_items = numOfItems;
            this.restaurant_id = restaurantId;
            this.CreatedBy = createdBy;
            this.CreatedOn = createdOn;
            this.ModifiedOn = modifiedOn;
            this.ModifiedBy = modifiedBy;
            this.DeletedOn = deletedOn;
            this.DeletedBy = deletedBy;
            this.IsDeleted = isDeleted;
        }
        public void Update(string name, string description, int numOfItems, int restaurantId, string modifiedBy)
        {
            this.name = name;
            this.Description = description;
            this.num_of_items = numOfItems;
            this.restaurant_id = restaurantId;
            this.ModifiedBy = modifiedBy;
            this.ModifiedOn = DateTime.Now;
        }
        public void Delete(string deletedBy)
        {
            this.IsDeleted = true;
            this.DeletedBy = deletedBy;
            this.DeletedOn = DateTime.Now;
        }

    }
}
