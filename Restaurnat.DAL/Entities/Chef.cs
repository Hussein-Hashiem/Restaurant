
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurnat.DAL.Entities
{
    public class Chef
    {
        [Key]
        public int chef_id { get; private set; }
        public string name { get; private set; }
        public string? about { get; private set; }
        public string? category { get; private set; }
        public int? experience_years { get; private set; }
        public bool work_now { get; private set; }
        public string imagepath { get; private set; }
        [ForeignKey("Restaurant")]
        public int restaurant_id { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
    }
}
