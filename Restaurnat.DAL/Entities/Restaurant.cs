
using System.ComponentModel.DataAnnotations;

namespace Restaurnat.DAL.Entities
{
    public class Restaurant
    {
        [Key]
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int num_of_guests { get; set; }
        public string? about { get; set; }
        public bool recommended { get; set; }
        public int? num_of_vip_customers { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Chef> Chefs { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
