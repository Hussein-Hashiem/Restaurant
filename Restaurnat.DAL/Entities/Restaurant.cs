
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class Restaurant
    {
        [Key]
        public int restaurant_id { get; private set; }
        public string name { get; private set; }
        public string address { get; private set; }
        public int num_of_guests { get; private set; }
        public string? about { get; private set; }
        public bool recommended { get; private set; }
        public int? num_of_vip_customers { get; private set; }
        public List<Menu> Menus { get; private set; }
        public List<Chef> Chefs { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
