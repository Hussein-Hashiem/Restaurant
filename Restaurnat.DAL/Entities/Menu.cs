
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
        public List<Item> Items { get; private set; }
        public DateTime? CreatedOn { get; private set; }
        public string? CreatedBy { get; private set; }
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
            string description

        )
        {
            this.name = name;
            this.Description = description;
            this.CreatedOn = DateTime.Now;
         }
        public void Update(string name, string description)
        {
            this.name = name;
            this.Description = description;
            this.ModifiedOn = DateTime.Now;
        }
       
    }
}
