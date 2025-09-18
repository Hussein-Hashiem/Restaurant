
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Chef
    {
        [Key]
        public int chef_id { get; set; }
        public string name { get; set; }
        public string? about { get; set; }
        public string? category { get; set; }
        public int? experience_years { get; set; }
        public bool work_now { get; set; }
        public string imagepath { get; set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; set; }
        public Restaurant Restaurant { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
